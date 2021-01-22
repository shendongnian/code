    // Sample for String.IsInterned(String)
    using System;
    using System.Text;
    using System.Runtime.CompilerServices;
    using System.Diagnostics;
    
    // In the .NET Framework 2.0 the following attribute declaration allows you to 
    // avoid the use of the interning when you use NGEN.exe to compile an assembly 
    // to the native image cache.
    //[assembly: CompilationRelaxations(CompilationRelaxations.NoStringInterning)]
    class Sample
    {
        public static void Main()
        {
            // String str1 is known at compile time, and is automatically interned.
            String str1 = "abcd";
            Console.WriteLine("Type cd and it will be ok, type anything else and Assert will fail.");
            string end = Console.ReadLine(); // Constructed, but still interned.
            string str3 = "ab" + end;
    
            // Constructed string, str2, is not explicitly or automatically interned.
            String str2 = new StringBuilder().Append("wx").Append("yz").ToString();
            Console.WriteLine();
            Test(1, str1);
            Test(2, str2);
            Test(3, str3);
    
            // Sanity checks.
            // Debug.Assert(Object.ReferenceEquals(str3, str1)); // Assertion fails, as expected.
            Debug.Assert(Object.ReferenceEquals(string.Intern(str3), string.Intern(str1))); // Passes
    
            Console.ReadKey();
        }
    
        public static void Test(int sequence, String str)
        {
            Console.Write("{0}) The string, '", sequence);
            String strInterned = String.IsInterned(str);
            if (strInterned == null)
                Console.WriteLine("{0}', is not interned.", str);
            else
                Console.WriteLine("{0}', is interned.", strInterned);
        }
    }
