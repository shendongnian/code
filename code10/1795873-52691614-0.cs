    enter code here  static void Main(string[] args)
        {
            TestConncetion testConncetion = new TestConncetion(Delete);//here I used delegate
            WriteLine($"My connection string is working Fine ,result is {testConncetion(1)}");
        }
        private static bool Delete(int id)
        {
            string Connection = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //String conString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Parnian\\documents\\visual studio 2017\\Projects\\Bank\\Bank\\Database.mdf;Integrated Security=True";
            SqlConnection sql = new SqlConnection(Connection);
            string sqll = "Delete FROM TblBank WHERE  Id =@id ";
            try
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand(sqll, sql);
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
                sql.Close();
                return true;
            }
            catch (Exception ex)
            {
                WriteLine("have some problem", "wrong", ex.Message);
                return false;
            }
        }
 
