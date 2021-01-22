    public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
    {
        return new PropertyDescriptorCollection(
            TypeDescriptor.GetProperties(this, attributes, true)
                .Select(x => new ReadOnlyWrapper(x))
                .ToArray());
    }
