     public static void CopyProperties(this object destinationObject, object sourceObject, bool overwriteAll = true)
            {
                try
                {
                    if (sourceObject != null)
                    {
                        PropertyInfo[] sourceProps = sourceObject.GetType().GetProperties();
                        List<string> sourcePropNames = sourceProps.Select(p => p.Name).ToList();
                        foreach (PropertyInfo pi in destinationObject.GetType().GetProperties())
                        {
                            if (sourcePropNames.Contains(pi.Name))
                            {
                                PropertyInfo sourceProp = sourceProps.First(srcProp => srcProp.Name == pi.Name);
                                if (sourceProp.PropertyType == pi.PropertyType)
                                    if (overwriteAll || pi.GetValue(destinationObject, null) == null)
                                    {
                                        pi.SetValue(destinationObject, sourceProp.GetValue(sourceObject, null), null);
                                    }
                            }
                        }
                    }
                }
                catch (ApplicationException ex)
                {
                    throw;
                }
            }
