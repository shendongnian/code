    class ThreadingBug
    {
        private const string CONNECTION_STRING =
            "Data Source=.\\wfea;Initial Catalog=zocdoc;Persist Security Info=True;Trusted_Connection=yes;";
        static void Main(string[] args)
        {
            try
            {
                Thread threadOne = new Thread(GetConnectionOne);
                Thread threadTwo = new Thread(GetConnectionTwo);
                threadOne.Start();
                threadTwo.Start();
                threadOne.Join(2000);
                threadTwo.Join(2000);
            }
            catch (Exception e)
            {
                File.AppendAllText("Main.txt", e.ToString());
            }
        }
        static void GetConnectionOne()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    conn.Open();
                }
            }
            catch (Exception e)
            {
                File.AppendAllText("GetConnectionOne.txt", e.ToString());
            }
        }
        static void GetConnectionTwo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    conn.Open();
                }
            }
            catch (Exception e)
            {
                File.AppendAllText("GetConnectionTwo.txt", e.ToString());
            }
        }
    }
