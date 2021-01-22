    [DllImport("zip4_w32.dll",
       CallingConvention = CallingConvention.StdCall,
       EntryPoint = "z4LLkGetKeySTD",
       ExactSpelling = false)]
     private extern static sbyte* or byte* z4LLkGetKeySTD();
     void foo()
     {
       string res = new string(z4LLkGetKeySTD());
     }
