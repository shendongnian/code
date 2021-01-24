            var properties = e3.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {              
                if (properties[i].PropertyType.IsAssignableFrom(funcType)) {
                    properties[i].SetValue(e3, del );
                }
            } 
