            using(SqlConnection MyConnection = new SqlConnection("Connection string"))
            {
                MyConnection.Open();
                //...
                // 1. SQLConnection is a type that implements IDisposable
                // 2. So you can use MyConnection in a using statement
                // 3. When using block finishes, it calls Dispose method of 
                // SqlConnection class
                // 4. In this case, it will probably close the connection to 
                // the database and dispose MyConnection object
                
            }
