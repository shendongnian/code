    public override bool GetPropertiesSupported(ITypeDescriptorContext context)
    {
      return true;
    }
    
    public override PropertyDescriptorCollection GetProperties(
        ITypeDescriptorContext context, object value, Attribute[] attributes)
    {
      return base.GetProperties(context, value, attributes).
        Concat(TypeDescriptor.GetConverter(typeof(TheBaseType)).
        GetProperties(context, value, attributes));
    }
