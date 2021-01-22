        string name = (string)e.InputParameters["name"];
        int id = (int)e.InputParameters["id"];
        if (string.IsNullOrEmpty(name))
            e.Cancel = true;
        else
        {
            // Here insert in all Databases currently present 
            // Except DB with StorageIndex = 1 as will b updated by ObjectDataSource1
            for (int index = 2; index <= 3; index++)
            {
                string DataConnectionString = ConfigurationManager.AppSettings["DataConnectionString " + index]);
                SqlConnection con = new SqlConnection(DataConnectionString);
                string query = "UPDATE student SET [name] = @name WHERE (([id] = @id))";
                int cnt = Utils.executeQuery(query, con, new object[] { "@name", "@id" }, new object[] { name, id });
            }
        }
    } 
