    Public Class clsConn
    {
    Public List<Data> getSomething()
        var SqlConn = new SqlConnection("your connection");
            try
            {
                SqlConn.Open();
                string sqlstring = "your sql sentence";
                SqlCommand SqlCmd = new SqlCommand(sqlstring, SqlConn);
                SqlDataReader reader = SqlCmd.ExecuteReader();
                List<Data> dataList = new List<Data>();
                if (reader.Read())
                {
                        Data data = new Data();
                        data.productid = reader[0].ToString(); // this is just an example
                        dataList.Add(data);
                }
                return dataList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("conexion to DB failed: " + ex.Message);
                throw;
            }
            finally
            {
                SqlConn.Close();
                
            }
        }
      }
     }
