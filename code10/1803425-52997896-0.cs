    if (reader.HasRows) {
            while (reader.Read())
            {
               if (reader.GetInt32(0) > 0)
               {
                  Re1 =  "OK";
               }
               else {
                  Re1 = "Fail";
               }
            }
        }
        else {
            Console.WriteLine("No rows found.");
        }
