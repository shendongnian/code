    static void Main(string[] args)
        {
            try
            {
                Lua lua = new Lua();
                lua.DoFile(@"D:\Samples\Test.lua");
                // SumUp(a, b)
                var result = lua.DoString("return SumUp(1, 2)");
                Console.WriteLine("1 + 2 = " + result.First().ToString());
                // GetTable()           
                var objects = lua.DoString("return GetTable()"); // Array of objects
                foreach (LuaTable table in objects)
                    foreach (KeyValuePair<object, object> i in table)
                        Console.WriteLine($"{i.Key.ToString()}: {i.Value.ToString()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
