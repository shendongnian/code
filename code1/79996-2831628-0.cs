     for (int i = 0; i < dataRecord.FieldCount; i++)
                    {
                   
                        PropertyInfo propertyInfo = t.GetProperty(dataRecord.GetName(i));
                        LocalBuilder il_P = generator.DeclareLocal(typeof(PropertyInfo));
                      
                        Label endIfLabel = generator.DefineLabel();
.... ...
