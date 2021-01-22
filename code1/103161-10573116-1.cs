        public void DoWork2()
        {
            using (TransactionScope ts2 = new TransactionScope())
            {
                using (SqlConnection conn1 = new SqlConnection("Data Source=Iftikhar-PC;Initial Catalog=LogDB;Integrated Security=SSPI;"))
                {
                    SqlCommand cmd = new SqlCommand("Insert into Log values(newid(),'" + "Dowork2()" + "','Info',getDate())");
                    cmd.Connection = conn1;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlConnection conn2 = new SqlConnection("Data Source=Iftikhar-PC;Initial Catalog=LogDB;Integrated Security=SSPI;Connection Timeout=100"))
                    {
                        cmd = new SqlCommand("Insert into Log values(newid(),'" + "Dowork2()" + "','Info',getDate())");
                        cmd.Connection = conn2;
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                ts2.Complete();
            }
        }
