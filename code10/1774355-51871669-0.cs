    using System;
    using System.ComponentModel;
    public class CustomObjectWrapper : CustomTypeDescriptor
    {
        public object WrappedObject { get; private set; }
        public CustomObjectWrapper(object o) : base()
        {
            WrappedObject = o ?? throw new ArgumentNullException(nameof(o));
        }
        public override PropertyDescriptorCollection GetProperties()
        {
            return this.GetProperties(new Attribute[] { });
        }
        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(WrappedObject, true);
        }
        public override object GetPropertyOwner(PropertyDescriptor pd)
        {
            return WrappedObject;
        }
    }
