            public static void RelinkDAOTables(string MDBfile, string filepath, string sql)
        {
            DataTable linkedTables = TableFromMDB(MDBfile, sql);
            dao.DBEngine DBE = new dao.DBEngine();
            dao.Database DB = DBE.OpenDatabase(MDBfile, false, false, "");
            foreach (DataRow row in linkedTables.Rows)
            {
                dao.TableDef table = DB.TableDefs[row["Name"].ToString()];
                table.Connect = string.Format(";DATABASE={0}{1} ;TABLE={2}", filepath, row["database"], row["LinkedName"]);
                table.RefreshLink();
            }
            
        }
   
