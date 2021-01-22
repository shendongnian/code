    static void Main(string[] args)
    {
        var barModel = new BarModel();
        barModel.list.Add(new Model() { key = "1", value = "One" });
        barModel.list.Add(new Model() { key = "2", value = "Two" });
        barModel.list.Add(new Model() { key = "some", value = "Three" });
    
        string id = "some";
    
        Console.WriteLine(barModel.subFor(id).ToString());
        // output: m => (True AndAlso (m.key == value(ConsoleApplication2.Bar`1+<>c__DisplayClass0[ConsoleApplication2.Model]).id))
        Console.ReadKey();
    
    
        var subworkitems = barModel.list.Where(barModel.subFor(id).Compile());
        // Exception {"variable 'm' of type 'ConsoleApplication2.Model' referenced from scope '', but it is not defined"}
    
        foreach (var si in subworkitems)
        {
            Console.WriteLine(si.key);
            Console.WriteLine(si.value);
        }
    
        Console.WriteLine(subworkitems.ToString());
        Console.ReadKey();
    }
