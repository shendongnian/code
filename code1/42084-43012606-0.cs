    public  class data_holder_for_controls
    {
      //it will hold value for your label
      public  string status = string.Empty;
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
            //put some code here in this function
            for (int i = 0; i < 10; i++)
            {
                //statements here
            }
            //set result in status variable
            d1.status = "Task done";
        }
    }
 
