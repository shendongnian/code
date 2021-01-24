    public static void Update()
    {
        Database.openStockConn(Settings.databaseName, Settings.databaseUsername, Settings.databasePassword, Settings.sshHost, Settings.sshUsername, Settings.sshPassword);
    
        if (Database.stockConn.State != ConnectionState.Open)
        {
            Database.openStockConn(Settings.databaseName, Settings.databaseUsername, Settings.databasePassword, Settings.sshHost, Settings.sshUsername, Settings.sshPassword);
        }
        Console.WriteLine("[Core] database connection is now open!\n");
    
        MySqlCommand cmd1 = new MySqlCommand("SELECT value FROM catalog_product_entity_decimal", Database.stockConn);
        MySqlCommand cmd2 = new MySqlCommand("UPDATE catalog_product_entity_decimal SET value= 1112 WHERE value_id= 4063", Database.stockConn);
            
            
        try
            {
                Console.WriteLine("[Price] Updating Prices...");
    
            using (var reader = cmd1.ExecuteReader())
            {
                var indexOfValue = reader.GetOrdinal("value");
    
                while (reader.Read())
                {
                    var price1 = reader.GetValue(indexOfValue);
    
                    Console.WriteLine("Executing Update Command...");
    
                    cmd2.ExecuteNonQuery();
    
                    Console.WriteLine("Update Command Executed!");
                }
            }
        }
        catch
        {
            Console.WriteLine("Updating Failed!");
        }
        finally
        {
            if (Database.stockConn != null)
            {
                Database.stockConn.Close();
            }
        }
    }
