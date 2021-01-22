            ServerConnection connection = new ServerConnection(".");
            Server server = new Server(connection);
            Database db = server.Databases["Northwind"];
            foreach (Table table in db.Tables)
            {
                foreach (Column column in table.Columns)
                {
                    Console.WriteLine("Table: {0}, Column: {1}",table.Name,column.Name);
                }
            }
        }
