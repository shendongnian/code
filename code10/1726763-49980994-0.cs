    public static IEnumerable<DatabaseAttributeContainer> GetAllAttributes<TClass>(TClass obj, bool inherit = false)
            {
                List<DatabaseAttributeContainer> propValues = new List<DatabaseAttributeContainer>();
                object value = null;
                Type classType = typeof(TClass);
                PropertyInfo[] pInfos = inherit ? classType.GetProperties() : classType.GetProperties(_NonInheritedFlag);
                DatabaseAttribute[] attributes = null;
                DatabaseAttribute attr = null;
                ColumnAttribute colAttr = null;
                PropertyInfo pInfoDeep = null;
                object deepRef = null;
                //ToDo: get custom attributes from this obj and iterate over it with prop name
                //get propInfo (performance increase)
    
                foreach (PropertyInfo pInfo in pInfos)
                {
                    attributes = (DatabaseAttribute[])pInfo.GetCustomAttributes(typeof(DatabaseAttribute));
                    attr = attributes.FirstOrDefault();
                    if (!(attr is IgnoreAttribute))
                    {
                        colAttr = attr as ColumnAttribute;
                        if (colAttr != null && colAttr.HasDeepProp && obj != null)
                        {
                            //get ref value
                            deepRef = pInfo.GetValue(obj, null);
                            deepRef = Convert.ChangeType(deepRef, colAttr.DeepType);
                            pInfoDeep = deepRef.GetType().GetProperty(colAttr.DeepPropName);
                            if (pInfoDeep == null)
                                throw new ApplicationException("Property with name " + colAttr.DeepPropName + " not found");
                            value = pInfoDeep.GetValue(deepRef, null);
                        }
                        else
                        {
                            if (obj != null)
                                value = pInfo.GetValue(obj, null);
                        }
                        propValues.Add(new DatabaseAttributeContainer(attr, value));
                    }
                }
                propValues.Add(GetAttributeByClass<TClass>());
                if (propValues.Count == 0)
                    throw new ApplicationException(typeof(TClass) + "has no DatabaseAttribute attribute");
                return propValues;
            }
