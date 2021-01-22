    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    
    namespace CTDExample
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
    
                var ctd = new CTD();
                ctd.AddProperty("Name");
                ctd.AddProperty("Age");
                DataContext = ctd;
            }
        }
    
        public class CTD : CustomTypeDescriptor
        {
            private static readonly ICollection<PropertyDescriptor> _propertyDescriptors = new List<PropertyDescriptor>();
    
            public void AddProperty(string name)
            {
                _propertyDescriptors.Add(new MyPropertyDescriptor(name));
            }
    
            public override PropertyDescriptorCollection GetProperties()
            {
                return new PropertyDescriptorCollection(_propertyDescriptors.ToArray());
            }
    
            public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
            {
                return GetProperties();
            }
    
            public override EventDescriptorCollection GetEvents()
            {
                return null;
            }
    
            public override EventDescriptorCollection GetEvents(Attribute[] attributes)
            {
                return null;
            }
        }
    
        public class MyPropertyDescriptor : PropertyDescriptor
        {
            private readonly IDictionary<object, object> _values;
    
            public MyPropertyDescriptor(string name)
                : base(name, null)
            {
                _values = new Dictionary<object, object>();
            }
    
            public override bool CanResetValue(object component)
            {
                throw new NotImplementedException();
            }
    
            public override Type ComponentType
            {
                get { throw new NotImplementedException(); }
            }
    
            public override object GetValue(object component)
            {
                object value = null;
                _values.TryGetValue(component, out value);
                return value;
            }
    
            public override bool IsReadOnly
            {
                get { return false; }
            }
    
            public override Type PropertyType
            {
                get { return typeof(object); }
            }
    
            public override void ResetValue(object component)
            {
                throw new NotImplementedException();
            }
    
            public override void SetValue(object component, object value)
            {
                var oldValue = GetValue(component);
    
                if (oldValue != value)
                {
                    _values[component] = value;
                    OnValueChanged(component, new PropertyChangedEventArgs(base.Name));
                }
            }
    
            public override bool ShouldSerializeValue(object component)
            {
                throw new NotImplementedException();
            }
    
            public override void AddValueChanged(object component, EventHandler handler)
            {
                // set a breakpoint here to see WPF attaching a value changed handler
                base.AddValueChanged(component, handler);
            }
        }
    }
