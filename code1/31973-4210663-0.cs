     private bool PublicInstancePropertiesEqual<T>(T self, T to, params string[] ignore) where T : class
            {
                if (self != null && to != null)
                {
                    Type type = typeof(T);
                    List<string> ignoreList = new List<string>(ignore);
                    foreach (PropertyInfo pi in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                    {
                        if (!ignoreList.Contains(pi.Name))
                        {
                            object selfValue = type.GetProperty(pi.Name).GetValue(self, null);
                            object toValue = type.GetProperty(pi.Name).GetValue(to, null);
                            if (selfValue != null)
                            {
                                if (!selfValue.Equals(toValue))
                                    return false;
                            }
                            else if (toValue != null)
                                return false;
                        }
                    }
                    return true;
                }
                return self == to;
            }
