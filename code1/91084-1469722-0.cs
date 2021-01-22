    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    // example
    static class Program {
        [STAThread]
        static void Main() { 
            PropertyBag.AddProperty("UserName", typeof(string), new DisplayNameAttribute("User Name"));
            PropertyBag.AddProperty("DateOfBirth", typeof(DateTime), new DisplayNameAttribute("Date of Birth"));
            BindingList<PropertyBag> list = new BindingList<PropertyBag>() {
                new PropertyBag().With("UserName", "Fred").With("DateOfBirth", new DateTime(1998,12,1)),
                new PropertyBag().With("UserName", "William").With("DateOfBirth", new DateTime(1997,4,23))
            };
            
            Application.Run(new Form {
                Controls = {
                    new DataGridView { // prove it works for complex bindings
                        Dock = DockStyle.Fill,
                        DataSource = list,
                        ReadOnly = false, AllowUserToAddRows = true
                    }
                },
                DataBindings = {
                    {"Text", list, "UserName"} // prove it works for simple bindings
                }
            });
        }
    }
    // PropertyBag file 1; the core bag
    partial class PropertyBag : INotifyPropertyChanged {
        private static PropertyDescriptorCollection props;
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        static PropertyBag() {
            props = new PropertyDescriptorCollection(new PropertyDescriptor[0], true);
            // init the provider; I'm avoiding TypeDescriptionProviderAttribute so that we
            // can exploit the default implementation for fun and profit
            TypeDescriptionProvider defaultProvider = TypeDescriptor.GetProvider(typeof(PropertyBag)),
                customProvider = new PropertyBagTypeDescriptionProvider(defaultProvider);
            TypeDescriptor.AddProvider(customProvider, typeof(PropertyBag));
        }
        private static readonly object syncLock = new object();
        public static void AddProperty(string name, Type type, params Attribute[] attributes) {
            lock (syncLock)
            {   // append the new prop, into a *new* collection, so that downstream
                // callers don't have to worry about the complexities
                PropertyDescriptor[] newProps = new PropertyDescriptor[props.Count + 1];
                props.CopyTo(newProps, 0);
                newProps[newProps.Length - 1] = new PropertyBagPropertyDescriptor(name, type, attributes);
                props = new PropertyDescriptorCollection(newProps, true);
            }
        }
        private readonly Dictionary<string, object> values;
        public PropertyBag()
        { // mainly want to enforce that we have a public parameterless ctor
            values = new Dictionary<string, object>();
        }    
        public object this[string key] {
            get {
                if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");
                object value;
                values.TryGetValue(key, out value);
                return value;
            }
            set {
                if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");
                var prop = props[key];
                if (prop == null) throw new ArgumentException("Invalid property: " + key, "key");
                values[key] = value;
                OnPropertyChanged(key);
            }
        }
        internal void Reset(string key) {
            values.Remove(key);
        }
        internal bool ShouldSerialize(string key) {
            return values.ContainsKey(key);
        }
    }
    
    static class PropertyBagExt
    {
        // cheeky fluent API to make the example code easier:
        public static PropertyBag With(this PropertyBag obj, string name, object value) {
            obj[name] = value;
            return obj;
        }
    }
    
    // PropertyBag file 2: provider / type-descriptor
    partial class PropertyBag {
        class PropertyBagTypeDescriptionProvider : TypeDescriptionProvider, ICustomTypeDescriptor {
            readonly ICustomTypeDescriptor defaultDescriptor;
            public PropertyBagTypeDescriptionProvider(TypeDescriptionProvider parent) : base(parent) {
                this.defaultDescriptor = parent.GetTypeDescriptor(typeof(PropertyBag));
            }
            public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance) {
                return this;
            }
            AttributeCollection ICustomTypeDescriptor.GetAttributes() {
                return defaultDescriptor.GetAttributes();
            }
            string ICustomTypeDescriptor.GetClassName() {
                return defaultDescriptor.GetClassName();
            }
            string ICustomTypeDescriptor.GetComponentName() {
                return defaultDescriptor.GetComponentName();
            }
            TypeConverter ICustomTypeDescriptor.GetConverter() {
                return defaultDescriptor.GetConverter();
            }
            EventDescriptor ICustomTypeDescriptor.GetDefaultEvent() {
                return defaultDescriptor.GetDefaultEvent();
            }
            PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty() {
                return defaultDescriptor.GetDefaultProperty();
            }
            object ICustomTypeDescriptor.GetEditor(Type editorBaseType) {
                return defaultDescriptor.GetEditor(editorBaseType);
            }
            EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes) {
                return defaultDescriptor.GetEvents(attributes);
            }
            EventDescriptorCollection ICustomTypeDescriptor.GetEvents() {
                return defaultDescriptor.GetEvents();
            }
            PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes) {
                return PropertyBag.props; // should really be filtered, but meh!
            }
            PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties() {
                return PropertyBag.props;
            }
            object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd) {
                return defaultDescriptor.GetPropertyOwner(pd);
            }
        }
    }
    // PropertyBag file 3: property descriptor
    partial class PropertyBag {
        class PropertyBagPropertyDescriptor : PropertyDescriptor {
            private readonly Type type;
            public PropertyBagPropertyDescriptor(string name, Type type, Attribute[] attributes)
                : base(name, attributes) {
                this.type = type;
            }
            public override object GetValue(object component) {
                return ((PropertyBag)component)[Name];
            }
            public override void SetValue(object component, object value) {
                ((PropertyBag)component)[Name] = value;
            }
            public override void ResetValue(object component) {
                ((PropertyBag)component).Reset(Name);
            }
            public override bool CanResetValue(object component) {
                return true;
            }
            public override bool ShouldSerializeValue(object component) {
                return ((PropertyBag)component).ShouldSerialize(Name);
            }
            public override Type PropertyType {
                get { return type; }
            }
            public override bool IsReadOnly {
                get { return false; }
            }
            public override Type ComponentType {
                get { return typeof(PropertyBag); }
            }
        }
    }
