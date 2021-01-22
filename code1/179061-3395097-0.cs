            if (database != "EXCEL")  // jus some dummy string to pass if its excel file .or else the database name in case of other DBs
            {
                connectionString = "Data Source=" + source + ";" +
                    "Provider=SQLOLEDB;Initial Catalog=" + database + ";" +
                    "User Id=" + username + ";password=" + password + "";
            }
            else
            {
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + source + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
            }
            //string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ElementDependencies.xls;Extended Properties=""Excel 8.0;HDR=YES;""";
            OleDbConnection con = new OleDbConnection(connectionString);
            DataTable schemaCols;
            DataTable schemaTbl;
            List<string> tablesnames = new List<string>();
            string returnString="";
            try
            {
                con.Open();
                object[] objArrRestrict;
                objArrRestrict = new object[] { null, null, null, "TABLE" };
                schemaTbl = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, objArrRestrict);
                foreach (DataRow row in schemaTbl.Rows)
                {
                    tablesnames.Add(row["TABLE_NAME"].ToString());
                }
                List<string> columnnames = new List<string>();
                
                foreach (string str in tablesnames)
                {
                   
                  
                   
                    string selTbl = str;
                   
                    object[] objArrRestrictNew;
                    objArrRestrictNew = new object[] { null, null, selTbl, null };
                    //
                    schemaCols = con.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, objArrRestrictNew);
                    foreach (DataRow row in schemaCols.Rows)
                    {
                        columnnames.Add(row["COLUMN_NAME"].ToString());
                        
                       
                    }
                 
                }
	    }
