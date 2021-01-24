    static void Main(string[] args)
        {
               Recoursive(typeof(Permissions).GetNestedTypes());
               Console.ReadLine();
        }
        private static void Recoursive(Type[] type)
        {
          
                foreach (var c in type)
                {
                    Recoursive(c.GetNestedTypes());
                    Console.WriteLine(c.Name);
                    foreach (var f in c.GetFields())
                    {
                        Console.WriteLine("\t-" + f.Name + ":" + f.GetValue(f));
                    }
                }
        }
