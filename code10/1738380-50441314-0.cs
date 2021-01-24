    public class CommonResourceClass
    {
        static object lockObj;
        //Note: here main resource is private 
        //(thus not in scope of any thread)
        static string commonString;
        //while prop is public where we have lock
        public static string CommonResource
        {
            get
            {   lock (lockObj) { return commonString; }  }
            set
            {   lock (lockObj) { commonString = value;}  }
        }
    }
