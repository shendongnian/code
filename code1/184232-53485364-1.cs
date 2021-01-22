        static void Main(string[] args)
        {
            Type t1 = typeof(Task<Dictionary<int, Dictionary<string, int?>>>);
            string name = t1.AssemblyQualifiedName;
            Console.WriteLine("Type: " + name);
            // Result: System.Threading.Tasks.Task`1[[System.Collections.Generic.Dictionary`2[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
            Type t2 = ReconstructType(name);
            bool ok = t1 == t2;
            Console.WriteLine("\r\nLocal type test OK: " + ok);
            Assembly asmRef = Assembly.ReflectionOnlyLoad("System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
            // Task<DialogResult> in refTypeTest below:
            string refTypeTest = "System.Threading.Tasks.Task`1[[System.Windows.Forms.DialogResult, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
            Type t3 = ReconstructType(refTypeTest, true, asmRef);
            Console.WriteLine("External type test OK: " + (t3.AssemblyQualifiedName == refTypeTest));
            // Getting an external non-generic type directly from references:
            Type t4 = ReconstructType("System.Windows.Forms.DialogResult, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", true, asmRef);
            Console.ReadLine();
        }
