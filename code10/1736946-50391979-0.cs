    MySqlCommand cmd = new MySqlCommand("SELECT count(*) FROM catalog_product_entity_decimal", Database.stockConn);
        try
        {
            var reader = cmd .ExecuteReader();
            if(reader.Read()){
                var totalRows=reader.GetInt32(0);
                Console.WriteLine("[Price] Updating Prices...");
                  
                  while(totalRows-->0){
                        MySqlCommand command = new MySqlCommand("UPDATE catalog_product_entity_decimal SET value= 1112 WHERE value_id= 4063", Database.stockConn);
                        command.ExecuteNonQuery();
                       
                   }
                Console.WriteLine("[Price] Prices Have Been Updated!");   
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
