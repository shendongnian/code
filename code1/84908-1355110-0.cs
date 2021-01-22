            public void GetNamesAndTypesAndValues()
            {
                    foreach (PropertyInfo propertyInfo in allClassProperties)
                    {
                            Console.WriteLine("{0} [type = {1}] [value = {2}]", propertyInfo.Name, propertyInfo.PropertyType, propertyInfo.GetValue(this, null));
                    }
            }
