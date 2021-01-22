                if (myObject != null)
                {
                    foreach (var p in ct.GetType().GetProperties())
                    {
                        if (p.GetValue(myObject , null) == null)
                        {
                            if (p.PropertyType == typeof(string))
                            {
                                p.SetValue(myObject , "Empty", null);
                            }
                            if (p.PropertyType == typeof(int))
                            {
                                p.SetValue(myObject , 0, null);
                            }
                            if (p.PropertyType == typeof(int?))
                            {
                                p.SetValue(myObject , 0, null);
                            }
                        }
                    }
                }
