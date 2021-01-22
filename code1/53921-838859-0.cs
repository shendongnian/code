    using System.Runtime.InteropServices;
        class myDllCaller {
        
           //call to function in the dll returning an int
          [DllImport("MyFavorite.dll")]
          private static extern int dllFunction(//list of parameters to function);
        
        public static void Main() {
        int rerult = dllFunction();
        
        }
    }
