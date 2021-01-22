                 // BindingFlags.InvokeMethod
                // Call a static method.
                Type t = typeof (TestClass);
    
                Console.WriteLine();
                Console.WriteLine("Invoking a static method.");
                Console.WriteLine("-------------------------");
                t.InvokeMember ("SayHello", BindingFlags.InvokeMethod | BindingFlags.Public | 
                    BindingFlags.Static, null, null, new object [] {});
