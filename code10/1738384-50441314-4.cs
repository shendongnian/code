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
            {   lock (lockObj) { return commonString; }  }
            set
            {   lock (lockObj) { commonString = value;}  }
        }
        public CommonResourceClass()
        {
            lockObj = new object();
        }
    }
