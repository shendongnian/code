            public string Process(BaseClass bc, string propertyName)
            {
                PropertyInfo property =  bc.GetType().GetProperty(propertyName);
                return (string)property.GetValue(bc, null);
            }
