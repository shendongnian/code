        public virtual void InitializeClass(DataRow dr)
        {
            Type type = this.GetType();
            PropertyInfo[] propInfos = type.GetProperties();
            for (int i = 0; i < dr.ItemArray.GetLength(0); i++)
            {
                if (dr[i].GetType() != typeof(DBNull))
                {
                    string field = dr.Table.Columns[i].ColumnName;
                    foreach (PropertyInfo propInfo in propInfos)
                    {
                        if (field.ToLower() == propInfo.Name.ToLower())
                        {
                            // get data value, set property, break
                            object o = dr[i];
                            propInfo.SetValue(this, o, null);
                            break;
                        }
                    }
                }
            }
        }
