    private List<object> GetList()
    { 
        List<object> list = new List<object>();
        var o = new { Id = 1, Name = "Foo" }; 
        var o1 = new { Id = 2, Name = "Bar" }; 
        list.Add(o); 
        list.Add(o1);
        return list;
    }
    private void WriteList()
    {
        foreach (var item in GetList()) 
        { 
            Console.WriteLine("Name={0}{1}", item.Name, Environment.NewLine); 
        }
    }
