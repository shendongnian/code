    	public List<Goods> GetGoods()
            {
                var result = new List<Goods>();
               var queryString = "SELECT * FROM.... ORDER BY ...";
    
                using (OleDbConnection connection = DbConnection.GetConnection())
                {
                    OleDbDataReader reader = FillReader(connection, queryString);
    
                    while (reader.Read())
                    {
                        var goods = new Goods();
    
                        goods.GoodsName     = reader["name"].ToString();
                        goods.NumberCode    = reader["number"].ToString();
    
                        result.Add(goods);
                    }
    
                    reader.Close();
                }
    
                return result;
            }
        private OleDbDataReader FillReader(OleDbConnection connection, string queryString)
        {
            OleDbCommand command = new OleDbCommand(queryString, connection);
            OleDbDataReader reader = command.ExecuteReader();
            return reader;
        }
