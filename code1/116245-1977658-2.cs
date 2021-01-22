    class ThreadingBug
    {
        private const string CONNECTION_STRING =
            "Data Source=.\\wfea;Initial Catalog=catalog;Persist Security Info=True;Trusted_Connection=yes;";
        static void Main(string[] args)
        {
            try
            {
                Thread threadOne = new Thread(GetConnectionOne);
                Thread threadTwo = new Thread(GetConnectionTwo);
                threadOne.Start();
                threadTwo.Start();
                threadOne.Join(20000);
                threadTwo.Join(20000);
                Debug.WriteLine("Same?" + (exception1 == exception2));
            }
            catch (Exception e)
            {
                Debug.WriteLine("error main" + e);
            }
        }
        static Exception exception1;
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
                Debug.WriteLine("Error Con one" + e);
                exception1 = e;
            }
        }
        static Exception exception2;
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
                Debug.WriteLine("Error Con two" + e);
                exception2 = e;
            }
        }
    }
