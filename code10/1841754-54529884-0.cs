    class A
    {
        //......
        static readonly string FilePath;
        //......
        static A()
        {
            FilePath = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName(); 
        }
    }
