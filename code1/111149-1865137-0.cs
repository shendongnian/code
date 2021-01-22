    // DemoLib.cs - we'll build this into a DLL and embed it
    using System;
    
    namespace DemoLib
    {   
        public class Demo
        {
            private readonly string name;
            
            public Demo(string name)
            {
                this.name = name;
            }
            
            public void SayHello()
            {
                Console.WriteLine("Hello, my name is {0}", name);
            }
        }
    }
    
    // DemoExe.cs - we'll build this as the executable
    using System;
    using System.Reflection;
    using System.IO;
    
    public class DemoExe
    {
        static void Main()
        {
            byte[] data;
            using (Stream stream = typeof(DemoExe).Assembly
                   .GetManifestResourceStream("DemoLib.dll"))
            {
                data = ReadFully(stream);
            }
            
            // Load the assembly
            Assembly asm = Assembly.Load(data);
    
            // Find the type within the assembly
            Type type = asm.GetType("DemoLib.Demo");
    
            // Find and invoke the relevant constructor
            ConstructorInfo ctor = type.GetConstructor(new Type[]{typeof(string)});
            object instance = ctor.Invoke(new object[] { "Jon" });
    
            // Find and invoke the relevant method
            MethodInfo method = type.GetMethod("SayHello");
            method.Invoke(instance, null);
        }
        
        static byte[] ReadFully(Stream stream)
        {
            byte[] buffer = new byte[8192];
            using (MemoryStream ms = new MemoryStream())
            {
                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, bytesRead);
                }
                return ms.ToArray();
            }
        }
    }
