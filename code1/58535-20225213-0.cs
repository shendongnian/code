    private static System.Reflection.PropertyInfo GetProperty(object t, string PropertName)
                {
                    if (t.GetType().GetProperties().FirstOrDefault(p => p.Name == PropertName.Split('.')[0]) == null)
                        throw new ArgumentNullException(string.Format("Property {0}, is not exists in object {1}", PropertName, t.ToString()));
                    if (PropertName.Split('.').Length == 1)
                        return t.GetType().GetProperty(PropertName);
                    else
                        return GetProperty(t.GetType().GetProperty(PropertName.Split('.')[0]).GetValue(t, null), PropertName.Split('.')[1]);
                }
