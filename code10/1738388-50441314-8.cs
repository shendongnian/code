    public class CommonResourceClass
    {
        object lockObj;
        //Note: here main resource is private 
        //(thus not in scope of any thread)
        string commonString;
        //while prop is public where we have lock
        public string CommonResource
        {
            get
            {
                lock (lockObj)
                {
                    Console.WriteLine(DateTime.Now.ToString() + " $$$$$$$$$$$$$$$ Reading");
                    Thread.Sleep(1000 * 2); 
                    return commonString;
                }
            }
            set
            {
                lock (lockObj)
                {
                    Console.WriteLine(DateTime.Now.ToString() + " ************* Writing");
                    Thread.Sleep(1000 * 5); 
                    commonString = value;
                }
            }
        }
        public CommonResourceClass()
        {
            lockObj = new object();
        }
    }
