        public string Verify(string valueToBind, object dataSource)
        {
            IListDataSource listDataSource = dataSource as IListDataSource;
            if (listDataSource != null)
            {
                if (ListContainsValue(listDataSource.GetEntityList(), valueToBind)) return valueToBind;
            }
            
            Type type = dataSource.GetType();
            MethodInfo select = type.GetMethod("Select", new Type[0]);
            PropertyInfo parameterCollectionInfo = type.GetProperty("Parameters");
            ParameterCollection pc = parameterCollectionInfo.GetValue(dataSource, null) as ParameterCollection;
            if (pc != null)
            {
                CustomParameter p = pc["WhereClause"] as CustomParameter;
                if (p != null)
                {
                    p.Value = "IsActive=true OR Id=" + valueToBind;
                    select.Invoke(dataSource, null);
                    return valueToBind;
                }
            }
            return string.Empty;
        }
