    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    // example POCO
    class Foo {
        static Foo()
        {   // initializes the custom provider (the attribute-based approach doesn't allow
            // access to the original provider)
            TypeDescriptionProvider basic = TypeDescriptor.GetProvider(typeof(Foo));
            FooTypeDescriptionProvider custom = new FooTypeDescriptionProvider(basic);
            TypeDescriptor.AddProvider(custom, typeof(Foo));
        }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
    // example form
    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.Run( new Form {
                    Controls = {
                        new DataGridView {
                            Dock = DockStyle.Fill,
                            DataSource = new BindingList<Foo> {
                                new Foo { Name = "Fred", DateOfBirth = DateTime.Today.AddYears(-20) }
                            }
                        }
                    }
                });
        }
    }
    
    class FooTypeDescriptionProvider : TypeDescriptionProvider
    {
        ICustomTypeDescriptor descriptor;
        public FooTypeDescriptionProvider(TypeDescriptionProvider parent) : base(parent) { }
        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        {   // swap regular descriptor for bespoke (Foo) descriptor
            if (descriptor == null)
            {
                ICustomTypeDescriptor desc = base.GetTypeDescriptor(typeof(Foo), null);
                descriptor = new FooTypeDescriptor(desc);
            }
            return descriptor;
        }
    }
    class FooTypeDescriptor : CustomTypeDescriptor
    {
        internal FooTypeDescriptor(ICustomTypeDescriptor parent) : base(parent) { }
        public override PropertyDescriptorCollection GetProperties()
        {   // wrap the properties
            return Wrap(base.GetProperties());
        }
        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {   // wrap the properties
            return Wrap(base.GetProperties(attributes));
        }
    
        static PropertyDescriptorCollection Wrap(PropertyDescriptorCollection properties)
        {
            // here's where we have an opportunity to swap/add/remove properties
            // at runtime; we'll swap them for pass-thru properties with
            // edited atttibutes
            List<PropertyDescriptor> list = new List<PropertyDescriptor>(properties.Count);
            foreach (PropertyDescriptor prop in properties)
            {
                // add custom attributes here...
                string displayName = prop.DisplayName;
                if (string.IsNullOrEmpty(displayName)) displayName = prop.Name;
    
                list.Add(new ChainedPropertyDescriptor(prop, new DisplayNameAttribute("Foo:" + displayName)));
            }
            return new PropertyDescriptorCollection(list.ToArray(), true);
        }
    }
    
    
    class ChainedPropertyDescriptor : PropertyDescriptor
    {
        // this passes all requests through to the underlying (parent)
        // descriptor, but has custom attributes etc;
        // we could also override properties here...
        private readonly PropertyDescriptor parent;
        public ChainedPropertyDescriptor(PropertyDescriptor parent, params Attribute[] attributes)
            : base(parent, attributes)
        {
            this.parent = parent;
        }
        public override bool ShouldSerializeValue(object component) { return parent.ShouldSerializeValue(component); }
        public override void SetValue(object component, object value) { parent.SetValue(component, value); }
        public override object GetValue(object component) { return parent.GetValue(component); }
        public override void ResetValue(object component) { parent.ResetValue(component); }
        public override Type PropertyType {get { return parent.PropertyType; } }
        public override bool IsReadOnly { get { return parent.IsReadOnly; } }
        public override bool CanResetValue(object component) {return parent.CanResetValue(component);}
        public override Type ComponentType { get { return parent.ComponentType; } }
        public override void AddValueChanged(object component, EventHandler handler) {parent.AddValueChanged(component, handler);  }
        public override void RemoveValueChanged(object component, EventHandler handler) { parent.RemoveValueChanged(component, handler); }
        public override bool SupportsChangeEvents { get { return parent.SupportsChangeEvents; } }
    }
