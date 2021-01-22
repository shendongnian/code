    public static void GenerateTableScript()
        {
            Server databaseServer = default(Server);//DataBase Server Name
            databaseServer = new Server("yourDatabase Server Name");
            string strFileName = @"C:\Images\Your FileName_" + DateTime.Today.ToString("yyyyMMdd") + ".sql"; //20120720`enter code here
            if (System.IO.File.Exists(strFileName))
                System.IO.File.Delete(strFileName);
            List<SqlSmoObject> list = new List<SqlSmoObject>();
            Scripter scripter = new Scripter(databaseServer);
            Database dbUltimateSurvey = databaseServer.Databases["YourDataBaseName"];//DataBase Name
            //Table scripting Writing
            DataTable dataTable1 = dbUltimateSurvey.EnumObjects(DatabaseObjectTypes.Table);
            foreach (DataRow drTable in dataTable1.Rows)
            {
                //string strTableSchema = (string)drTable["Schema"];
                //if (strTableSchema == "dbo")
                //    continue;
                Table dbTable = (Table)databaseServer.GetSmoObject(new Urn((string)drTable["Urn"]));
                if (!dbTable.IsSystemObject)
                    if (dbTable.Name.Contains("SASTool_"))
                        list.Add(dbTable);
            }
            scripter.Server = databaseServer;
            scripter.Options.IncludeHeaders = true;
            scripter.Options.SchemaQualify = true;
            scripter.Options.ToFileOnly = true;
            scripter.Options.FileName = strFileName;
            scripter.Options.DriAll = true;
            scripter.Options.AppendToFile = true;
            scripter.Script(list.ToArray());//Table Script completed
            //Store Procedures scripting Writing
            list = new List<SqlSmoObject>();
            DataTable dataTable = dbUltimateSurvey.EnumObjects(DatabaseObjectTypes.StoredProcedure);
            foreach (DataRow row in dataTable.Rows)
            {
                string sSchema = (string)row["Schema"];
                if (sSchema == "sys" || sSchema == "INFORMATION_SCHEMA")
                    continue;
                StoredProcedure sp = (StoredProcedure)databaseServer.GetSmoObject(
                   new Urn((string)row["Urn"]));
                if (!sp.IsSystemObject)
                    if (sp.Name.Contains("custom_"))
                        list.Add(sp);
            }
            scripter.Server = databaseServer;
            scripter.Options.IncludeHeaders = true;
            scripter.Options.SchemaQualify = true;
            scripter.Options.ToFileOnly = true;
            scripter.Options.FileName = strFileName;
            scripter.Options.DriAll = true;
            scripter.Options.AppendToFile = true;
            scripter.Script(list.ToArray());   // Stored procedure Script completed
        }
