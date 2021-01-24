                    Console.WriteLine("Generating Query...");
                    // Making the Query
                    MySqlCommand command = new MySqlCommand("UPDATE catalog_product_entity_decimal SET value= 1114 WHERE value_id= 4063", con);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Query Generated!");
