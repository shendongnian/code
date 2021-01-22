    private bool PropertiesEqual<T>(T object1, T object2)
            {
                PropertyDescriptorCollection object2Properties = TypeDescriptor.GetProperties(object1);
                foreach (PropertyDescriptor object1Property in TypeDescriptor.GetProperties(object2))
                {
                    PropertyDescriptor object2Property = object2Properties.Find(object1Property.Name, true);
    
                    if (object2Property != null)
                    {
                        object object1Value = object1Property.GetValue(object1);
                        object object2Value = object2Property.GetValue(object2);
    
                        if ((object1Value == null && object2Value != null) || (object1Value != null && object2Value == null))
                        {
                            return false;
                        }
    
                        if (object1Value != null && object2Value != null)
                        {
                            if (!object1Value.Equals(object2Value))
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
