        public void Bar(object m_objCompany)
        {
            foreach (PropertyInfo info in m_objCompany.GetType().GetProperties())
            {
                if (info.PropertyType != typeof(System.String))
                {
                    // Somehow create the outer property
                    object outerPropertyValue = info.PropertyType.GetConstructor(new Type[] { }).Invoke(new object[] { });
                    foreach (PropertyInfo info2 in info.PropertyType.GetProperties())
                    {
                        if ("blah" == "blah")
                        {
                            if (info2.CanWrite)
                            {
                                Object innerPropertyValue = Convert.ChangeType("blah", info2.PropertyType);
                                info2.SetValue(outerPropertyValue, innerPropertyValue, null);
                            }
                        }
                    }
                    info.SetValue(m_objCompany, outerPropertyValue, null);
                }
            }
        }
