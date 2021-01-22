    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    
    namespace GacWithFusion
    {
        public class Program
        {
            static void Main(string[] args)
            {
                foreach (var assemblyName in GetGacAssemblyFullNames())
                {
                    Console.WriteLine(assemblyName.FullName);
                }
            }
    
            public static IEnumerable<AssemblyName> GetGacAssemblyFullNames()
            {
                IApplicationContext applicationContext;
                IAssemblyEnum assemblyEnum;
                IAssemblyName assemblyName;
    
                Fusion.CreateAssemblyEnum(out assemblyEnum, null, null, 2, 0);
                while (assemblyEnum.GetNextAssembly(out applicationContext, out assemblyName, 0) == 0)
                {
                    uint nChars = 0;
                    assemblyName.GetDisplayName(null, ref nChars, 0);
    
                    StringBuilder name = new StringBuilder((int)nChars);
                    assemblyName.GetDisplayName(name, ref nChars, 0);
    
                    AssemblyName a = null;
                    try
                    {
                        a = new AssemblyName(name.ToString());
                    }
                    catch (Exception)
                    {
                    }
    
                    if (a != null)
                    {
                        yield return a;
                    }
                }
            }
        }
    }
