    public class ProductTypeConverter : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string))
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }
    
            return "";
        }
    
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object instance, Attribute[] attributes)
        {
            PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(instance, attributes, true);
            PropertyDescriptor fieldsDescriptor = pdc.Find("Fields", false);
            List<PropertyDescriptor> pdList = new List<PropertyDescriptor>();
            foreach (PropertyDescriptor pd in pdc)
            {
                if (pd == fieldsDescriptor)
                {
    
                    List<Field> fields = ((Product)instance).Fields;
                    if (fields != null)
                    {
                        foreach (Field field in fields)
                        {
                            FieldDescriptor fd = new FieldDescriptor(field);
                            pdList.Add(fd);
                        }
    
                    }
                }
                else
                {
                    pdList.Add(pd);
                }
            }
            return new PropertyDescriptorCollection(pdList.ToArray());
        }
    
        private class FieldDescriptor : SimplePropertyDescriptor
        {
            private Field privatefield;
            public Field field
            {
                get
                {
                    return privatefield;
                }
                private set
                {
                    privatefield = value;
                }
            }
    
            public FieldDescriptor(Field field) : base(field.GetType(), field.Name, field.Value.GetType())
            {
                // component type, property name, property type
                this.field = field;
            }
    
            public override object GetValue(object obj)
            {
                return field.Value;
            }
    
            public override void SetValue(object obj, object value)
            {
                field.Value = value;
            }
    
            public override bool IsReadOnly
            {
                get
                {
                    return false;
                }
            }
        }
    
    }
