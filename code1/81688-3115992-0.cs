        public static string[] GetDatabaseColumnNamesFromEntityProperty(Type entityType, string propertyName)
        {
            PersistentClass aNHibernateClass = NHibernateSessionManager.Instance.GetNHibernateConfiguration().GetClassMapping(entityType);
            if (aNHibernateClass == null)
            {
                return null;
            }
            else
            {
                string[] columnNames = null;
                try
                {
                    Property aProperty = aNHibernateClass.GetProperty(propertyName);
                    columnNames = new string[aProperty.ColumnCollection.Count];
                    int count = 0;
                    foreach (Column column in aProperty.ColumnCollection)
                    {
                        columnNames[count] = column.Name;
                        count++;
                    }
                }
                catch(Exception)
                {
                    Property aProperty = aNHibernateClass.IdentifierProperty;
                    //if(aProperty.Name.Equals(propertyName))
                    //{
                        columnNames = new string[aProperty.ColumnCollection.Count];
                        int count = 0;
                        foreach (Column column in aProperty.ColumnCollection)
                        {
                            columnNames[count] = column.Name;
                            count++;
                        }
                    //}
                }
                return columnNames;
            }
        }
