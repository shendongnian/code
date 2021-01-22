    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    
    namespace CTDExample
    {
        public class MyCustomType : CustomTypeDescriptor
        {
            // This is instance data.
            private readonly ICollection<PropertyDescriptor> _propertyDescriptors = new List<PropertyDescriptor>();
    
            // The data is stored on the type instance.
            private readonly IDictionary<string, object> _propertyValues = new Dictionary<string, object>();
    
            // The property descriptor now takes an extra argument.
            public void AddProperty(string name, Type type)
            {
                _propertyDescriptors.Add(new MyPropertyDescriptor(name, type));
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
    
            private class MyPropertyDescriptor : PropertyDescriptor
            {
                // This data is here to indicate that different instances of the type
                // object may have properties of the same name, but with different
                // characteristics.
                private readonly Type _type;
    
                public MyPropertyDescriptor(string name, Type type)
                    : base(name, null)
                {
                    _type = type;
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
                    MyCustomType obj = (MyCustomType)component;
                    object value = null;
                    obj._propertyValues.TryGetValue(Name, out value);
                    return value;
                }
    
                public override bool IsReadOnly
                {
                    get { return false; }
                }
    
                public override Type PropertyType
                {
                    get { return _type; }
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
                        MyCustomType obj = (MyCustomType)component;
                        obj._propertyValues[Name] = value;
                        OnValueChanged(component, new PropertyChangedEventArgs(Name));
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
    }
