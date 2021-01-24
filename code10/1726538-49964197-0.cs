    using System.Runtime.CompilerServices;
    public MyClass
    {
        public MyClass(  
        [CallerMemberName] string memberName = "",  
        [CallerFilePath] string sourceFilePath = "",  
        [CallerLineNumber] int sourceLineNumber = 0)  
        {
            ...
        }
    }
