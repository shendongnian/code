     public static void InsertData<T>(List<T> list,string TabelName)
            {
                    DataTable dt = new DataTable("MyTable");
                    clsBulkOperation blk = new clsBulkOperation();
                    dt = ConvertToDataTable(list);
                    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                    using (SqlBulkCopy bulkcopy = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["SchoolSoulDataEntitiesForReport"].ConnectionString))
                    {
                        bulkcopy.BulkCopyTimeout = 660;
                        bulkcopy.DestinationTableName = TabelName;
                        bulkcopy.WriteToServer(dt);
                    }
            }    
    public static DataTable ConvertToDataTable<T>(IList<T> data)
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
                DataTable table = new DataTable();
                foreach (PropertyDescriptor prop in properties)
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    table.Rows.Add(row);
                }
                return table;
            }
