    using System;
    using System.IO;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                double d = 3.14159d;
                byte[] b = SerializeExact(d);
                Console.WriteLine(b.Length);
                Console.ReadLine();
                double n = DeserializeExact(b);
                Console.WriteLine(n.ToString());
                Console.ReadLine();
            }
            public static byte[] SerializeExact(object anything)
            {
                int structsize = Marshal.SizeOf(anything);
                IntPtr buffer = Marshal.AllocHGlobal(structsize);
                Marshal.StructureToPtr(anything, buffer, false);
                byte[] streamdatas = new byte[structsize];
                Marshal.Copy(buffer, streamdatas, 0, structsize);
                Marshal.FreeHGlobal(buffer);
                return streamdatas;
            }
            public static double DeserializeExact(byte[] b)
            {
                GCHandle handle = GCHandle.Alloc(b, GCHandleType.Pinned);
                double d = (double)Marshal.PtrToStructure(
                    handle.AddrOfPinnedObject(),
                    typeof(double));
                handle.Free();
                return d;
            }
    
        }
    }
