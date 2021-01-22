    using System;
    using System.Diagnostics;
     
    class Foo
    {
    static void Main()
    {
        SmallFunc();
    }
     
    static void SmallFunc()
    {
        PrintStack();
    }
    static void PrintStack()
    {
        StackTrace st = new StackTrace(true); // true means get line numbers.
        foreach(StackFrame f in st.GetFrames()) {
            Console.Write(f);
        }
    }
    }
