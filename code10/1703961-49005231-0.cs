    using System;
    using System.Runtime.InteropServices;
    using System.Reflection;
    
    namespace TestCall   
    {
        class Program
        {
            [DllImport("kernel32.dll", EntryPoint = "LoadLibrary")]
            static extern int LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string lpLibFileName);
            [DllImport("kernel32.dll", EntryPoint = "GetProcAddress")]
            static extern IntPtr GetProcAddress(int hModule, [MarshalAs(UnmanagedType.LPStr)] string lpProcName);
            [DllImport("kernel32.dll", EntryPoint = "FreeLibrary")]
            static extern bool FreeLibrary(int hModule);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            private delegate double MyMethod(string a);
    
            static void Main(string[] arg) 
            {
    
                string DllName = "...Desktop\\CSharp.dll";  //or Cpp.dll
                string FuncName = "MyMethod";
    
    
                string input = "Just A String";
    
    
                int hModule = LoadLibrary(DllName); // you can build it dynamically 
                IntPtr intPtr = GetProcAddress(hModule, FuncName);
                if ((int)intPtr!=0 && hModule != 0)  //can I try this way?
                {                                    //                      Yes!
                    MyMethod run = (MyMethod)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(MyMethod));
                    double result = run(input);
                    Console.WriteLine(result);
                    Console.Read();
                    FreeLibrary(hModule);
                    return;
                }
                else                                 //No! 
                {
                    FreeLibrary(hModule);
    
                                                     //so I try other way
                    var DLL = Assembly.LoadFile(DllName);
                    foreach (Type type in DLL.GetExportedTypes())
                    {
                        var c = Activator.CreateInstance(type);
                        type.InvokeMember(FuncName, BindingFlags.InvokeMethod, null, c, new object[] { input });
                    }
                    return;
                }
            }
        }
    }
