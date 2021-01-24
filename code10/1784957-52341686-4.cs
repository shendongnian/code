     public struct UpdateItems
        {
           public string FirstName;
           public string LastName;
           public string Age;
        }
    void UpdateEntry(List<UpdateItems>Items)
        {
            string TableName = "SQLTableName";
            string sqlstring = "ConnectionDetails";
            using (var con = new SqlConnection(sqlstring))
            {
                using (var cmd = con.CreateCommand())
                {
                    foreach (var item in Items)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@FirstName",item.FirstName);
                        cmd.Parameters.AddWithValue("@LastName",item.LastName);
                        cmd.Parameters.AddWithValue("@Age",item.Age);
                        cmd.CommandText = $"Insert Into {TableName} Values (@FirstName, @LastName , @Age)";
                    }
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        //Do some checking
                        throw;
                    }
                   
                }        
            }
        }
