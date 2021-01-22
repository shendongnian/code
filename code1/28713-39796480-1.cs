    static void Main(string[] args)
    {
        List<string> li = new List<string>();
        li.Add("Ram");
        li.Add("shyam");
        li.Add("Ram");
        li.Add("Kumar");
        li.Add("Kumar");
        var x = from obj in li group obj by obj into g select new { Name = g.Key, Duplicatecount = g.Count() };
        foreach(var m in x)
        {
            Console.WriteLine(m.Name + "--" + m.Duplicatecount);
        }
        Console.ReadLine();
    }        
