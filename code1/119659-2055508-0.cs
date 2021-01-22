    using System;
    using System.Collections.Generic;
    using System.Text;
    using RGiesecke.DllExport;
    using System.Runtime.InteropServices;
    
    namespace DelphiNET
    {
    
       [ComVisible(true)]
       [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
       [Guid("ACEEED92-1A35-43fd-8FD8-9BA0F2D7AC31")]
       public interface IDotNetAdder
       {
          int Add3(int left);
       }
       
       [ComVisible(true)]
       [ClassInterface(ClassInterfaceType.None)]
       public class DotNetAdder : DelphiNET.IDotNetAdder
       {
          public int Add3(int left)
          {
             return left + 3;
          }
       }
    
       internal static class UnmanagedExports
       {
          [DllExport("createdotnetadder", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
          static void CreateDotNetAdderInstance([MarshalAs(UnmanagedType.Interface)]out IDotNetAdder instance)
          {
             instance = new DotNetAdder();
          }
       }
    }
