        class JetMetaData
        {
            /// <summary>
            /// Returns a datatable containing MetaData for all user-columns
            /// in the current JET Database. 
            /// </summary>
            /// <returns></returns>
            public static DataTable AllColumns(String ConnectionString)
            {
                DataTable dt;
                using (OleDbConnection cn = new OleDbConnection(ConnectionString))
                {
                    cn.Open();
                    dt = cn.GetSchema("Columns");
                    cn.Close();
                }
                return dt;
            }
        }
