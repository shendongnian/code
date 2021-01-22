    public  class data_holder_for_controls
    {
        // It will hold the value for your label
        public string status = string.Empty;
    }
    class Demo
    {
        public static  data_holder_for_controls d1 = new data_holder_for_controls();
        static void Main(string[] args)
        {
            ThreadStart ts = new ThreadStart(perform_logic);
            Thread t1 = new Thread(ts);
            t1.Start();
            t1.Join();
            //your_label.Text=d1.status; --- can access it from any thread
        }
        public static void perform_logic()
        {
            // Put some code here in this function
            for (int i = 0; i < 10; i++)
            {
                // Statements here
            }
            // Set the result in the status variable
            d1.status = "Task done";
        }
    }
