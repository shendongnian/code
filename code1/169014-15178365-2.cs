    public sealed class ReportErrorFlag : ErrorFlag
    {
        //basically your enum values
        public static readonly ErrorFlag Report1 = 1;
        public static readonly ErrorFlag Report2 = 2;
        public static readonly ErrorFlag Report3 = 3;
        
        ReportErrorFlag() 
        {
        
        }
    }
    public sealed class DataErrorFlag : ErrorFlag
    {
        //basically your enum values
        public static readonly ErrorFlag Data1 = 1;
        public static readonly ErrorFlag Data2 = 2;
        public static readonly ErrorFlag Data3 = 3;
        
        DataErrorFlag() 
        {
        
        }
    }
    // etc
