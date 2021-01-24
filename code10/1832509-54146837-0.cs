     public ObservableCollection<Product> GetProduct(int supplierId)
        {
            var listProdukt = new ObservableCollection<Product>();
            using (var sqlConnection = OpenSqlConnection())
            {
                var sqlCommandText = $"SELECT "something..."};";
                var sqlCommand = new SqlCommand
                {
                    CommandText = sqlCommandText,
                    Connection = sqlConnection
                };
                var reader = sqlCommand.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        var product = new Product
                        {
                            ProductSizeBySupplierId = int.Parse(reader["ProductSizeBySupplierId"].ToString()),
                            CategoryId = int.Parse(reader["CategoryId"].ToString()),                          
                        };
                        listProdukt.Add(product);
                    }
                }
            }
            return listProdukt;
        }
