    public class Transaction
        {
            private string connStr = ConfigurationManager.ConnectionStrings["airmazin"].ConnectionString;
            public Transaction() { }
            //Auto-Implemented Properties in C# 3 and later
            //The standard get and set are written for you by the compiler
            //Also the compiler writes the private fields where the data is stored
            public string TransactionID { get; set; }
            public string OfferId { get; set; }
            public string UserName { get; set; }
            public string Image { get; set; }
            public string ProductName { get; set; }
            public decimal ProductPrice { get; set; }
            //changed the function to return a list
            public List<Transaction> getProductTransaction(string p_UserName)
            {
                List<Transaction> lst = new List<Transaction>();
                using (SqlConnection conn = new SqlConnection(connStr))
                { 
                    string queryStr = "SELECT * FROM [Transaction] WHERE UserName = @user";
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    { 
                        cmd.Parameters.AddWithValue("@user", p_UserName);
                        conn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        { 
                            
                            if (dr.HasRows)
                                while (dr.Read())
                                    //This loop keeps adding records to the list as long as there are records to read
                                {
                                    Transaction prodDetail = new Transaction();
                                    prodDetail.TransactionID= dr["TransactionID"].ToString();
                                    prodDetail.OfferId = dr["OfferId"].ToString();
                                    prodDetail.UserName = dr["UserName"].ToString();
                                    prodDetail.Image = dr["Image"].ToString();
                                    prodDetail.ProductName = dr["ProductName"].ToString();
                                    prodDetail.ProductPrice = decimal.Parse(dr["ProductPrice"].ToString());
                                    lst.Add(prodDetail);
                                }
                            else
                            {
                                lst = null;
                            }
                        }
                    }
                }
                return lst;
            }
        }
