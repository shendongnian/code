    using System.IO;
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    namespace ConsoleApplication14
    {
        public class Program
        {
            public static void Main()
            {
                Dictionary<Type, MethodInfo> mapping = new Dictionary<Type, MethodInfo>();
                foreach (MethodInfo mi in typeof(BinaryWriter).GetMethods())
                {
                    if (mi.Name == "Write")
                    {
                        ParameterInfo[] pi = mi.GetParameters();
                        if (pi.Length == 1)
                            mapping[pi[0].ParameterType] = mi;
                    }
                }
    
                List<Object> someData = new List<Object>();
                someData.Add((Byte)10);
                someData.Add((Int32)10);
                someData.Add((Double)10);
                someData.Add((Char)10);
                someData.Add("Test");
    
                using (FileStream file = new FileStream(@"C:\test.dat", FileMode.Create, FileAccess.ReadWrite))
                using (BinaryWriter writer = new BinaryWriter(file))
                {
                    foreach (Object o in someData)
                    {
                        MethodInfo mi;
                        if (mapping.TryGetValue(o.GetType(), out mi))
                        {
                            mi.Invoke(writer, new Object[] { o });
                        }
                        else
                            throw new InvalidOperationException("Cannot write data of type " + o.GetType().FullName);
                    }
                }
            }
        }
    }
