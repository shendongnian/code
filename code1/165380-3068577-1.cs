    public void AssignTypeConverter<IType, IConverterType>()
    {
      TypeDescriptor.AddAttributes(typeof(IType), new TypeConverterAttribute(typeof(IConverterType)));
    }
    AssignTypeConverter<MyType, MyTypeConverter>();
