    class Program
    {
        static void Main(string[] args)
        {
            var dataDirectory = AppDomain.CurrentDomain.GetData("DataDirectory");
            //Changing DataDirectory value.
            AppDomain.CurrentDomain.SetData("DataDirectory", "C:\\DataFiles");
            Console.WriteLine(dataDirectory);
            SqlConnection conn = new SqlConnection(@"Data Source=.;AttachDbFilename=|DataDirectory|\HomeDB.mdf;Integrated Security=True");
            conn.Open();
            Console.ReadKey();
        }
    }
