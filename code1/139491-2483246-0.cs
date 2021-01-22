    class ContactInfo
    {
            [ReadOnly(true)]
            [Category("Contact Info")]
            public string Mobile { get; set; }
    
            [Category("Contact Info")]
            public string Name{ get; set; }
            public void SetMobileEdit(bool allowEdit)
            {
                 PropertyDescriptor descriptor =  TypeDescriptor.GetProperties(this.GetType())["Mobile"];
                 ReadOnlyAttribute attrib = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
                 FieldInfo isReadOnly = attrib.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
                 isReadOnly.SetValue(attrib, !allowEdit);
            }
    }
