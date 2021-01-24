    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
<!---->
    public class MyClass : ICustomTypeDescriptor
    {
        public string OriginalProperty1 { get; set; }
        public string OriginalProperty2 { get; set; }
        public List<CustomProperty> CustomProperties { get; set; }
        #region ICustomTypeDescriptor
        public AttributeCollection GetAttributes() => TypeDescriptor.GetAttributes(this, true);
        public string GetClassName() => TypeDescriptor.GetClassName(this, true);
        public string GetComponentName() => TypeDescriptor.GetComponentName(this, true);
        public TypeConverter GetConverter() => TypeDescriptor.GetConverter(this, true);
        public EventDescriptor GetDefaultEvent() => TypeDescriptor.GetDefaultEvent(this, true);
        public PropertyDescriptor GetDefaultProperty() 
            => TypeDescriptor.GetDefaultProperty(this, true);
        public object GetEditor(Type editorBaseType) 
            => TypeDescriptor.GetEditor(this, editorBaseType, true);
        public EventDescriptorCollection GetEvents() => TypeDescriptor.GetEvents(this, true);
        public EventDescriptorCollection GetEvents(Attribute[] attributes) 
            => TypeDescriptor.GetEvents(this, attributes, true);
        public PropertyDescriptorCollection GetProperties() => GetProperties(new Attribute[] { });
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            var properties = TypeDescriptor.GetProperties(this, attributes, true)
                .Cast<PropertyDescriptor>()
                .Where(p => p.Name != nameof(this.CustomProperties))
                .Select(p => TypeDescriptor.CreateProperty(this.GetType(), p,
                    p.Attributes.Cast<Attribute>().ToArray())).ToList();
            properties.AddRange(CustomProperties.Select(x => new CustomPropertyDescriptor(this, x)));
            return new PropertyDescriptorCollection(properties.ToArray());
        }
        public object GetPropertyOwner(PropertyDescriptor pd) => this;
        #endregion
    }
