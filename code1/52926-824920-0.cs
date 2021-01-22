            var asm = Assembly.GetExecutingAssembly();
            var properties = (from prop
                                  in asm.GetType()
                                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                              where 
                                prop.PropertyType == typeof (string) && 
                                prop.CanWrite && 
                                prop.CanRead
                              select prop).ToList();
            properties.ForEach(p => Debug.WriteLine(p.Name));
