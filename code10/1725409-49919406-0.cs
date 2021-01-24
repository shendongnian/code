    public static class MyDebug{    
    public static delegate void TestDelegate(object message);
    #if (NOEDITOR)
        public static TestDelegate Log =(x)=>{};
    #else
        public static TestDelegate Log = Debug.Log;
    #endif
    }
