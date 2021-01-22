        static void Main()
        {
            string[] names = { "Lukasz", "Darek", "Milosz" };
            foreach (var item in names)
            {
                if (ContainsL(item))
                     Console.WriteLine(item);
            }
            string match1 = Array.Find(names, delegate(string name) { return name.Contains("L"); });
            //or
            string match2 = Array.Find(names, delegate(string name) { return name.Contains("L"); });
            //or
            string match3 = Array.Find(names, x => x.Contains("L"));
            Console.WriteLine(match1 + " " + match2 + " " + match3);     // Lukasz Lukasz Lukasz
        }
        static bool ContainsL(string name) { return name.Contains("L"); }
    
