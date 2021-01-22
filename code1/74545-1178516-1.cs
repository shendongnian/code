    using System.Data.SQLClient;
    namespace YourNamespace
    {
        public class DatabaseConnect
        {
             public DataType getData()
             {
                DataType dataObj = new DataType();
                SqlConnection testConn = new SqlConnection("connection string here");
                SqlCommand testCommand = new SqlCommand("select * from dataTable", testConn);
                testConn.Open()
                 using (SqlDataReader reader = testCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       //Get data from reader and set into DataType object
                    }
                }
                return dataObj;
             }
        }
    }
