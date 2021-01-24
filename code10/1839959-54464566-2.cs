            using (var db = new MyDb())
            {
                var con = (SqlConnection) db.Database.Connection;
                con.Open();
                var cmd = con.CreateCommand();
                //...
            
            }
