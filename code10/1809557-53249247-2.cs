            var properties = e3.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {              
                // Check that its the same return type as delegate
                if (!properties[i].PropertyType.IsAssignableFrom(funcType))
                    continue;
             
                properties[i].SetValue(e3, del );
            } 
