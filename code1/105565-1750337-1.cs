    using System;
    using System.Runtime.InteropServices;
    
    
    [StructLayout(LayoutKind.Sequential)]  
    public class MyStruct
    {
      [MarshalAsAttribute(UnmanagedType.LPStr)]
      public string _id;
      [MarshalAsAttribute(UnmanagedType.LPStr)]
      public string _description;
    }
    
    
    class Program
    {
        [DllImport("dll")]
        static extern IntPtr get_my_structures();
    
        static void Main()
        {
            int structSize = Marshal.SizeOf(typeof(MyStruct));
            Console.WriteLine(structSize);
    
            IntPtr myStructs = get_my_structures();
            for (int i = 0; i < 3; ++i)
            {
                IntPtr data = new IntPtr(myStructs.ToInt64() + structSize * i);
                MyStruct ms = (MyStruct) Marshal.PtrToStructure(data, typeof(MyStruct));
    
                Console.WriteLine();
                Console.WriteLine(ms._id);
                Console.WriteLine(ms._description);
            }
        }
    }
