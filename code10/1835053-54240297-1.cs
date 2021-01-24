    static async Task Main(string[] args)
    {
        Console.WriteLine("Started");
        var c = new ClassWrapper();
        c.PropertyChanged += (sender, e) =>
        {
            Console.WriteLine($"Collection has {c.ClassDTO.MyCollection.Count} items");
        };
        for (int i = 0; i < 100; i++)
        {
            c.ClassDTO.MyCollection.Add(new OtherClass());
            await Task.Delay(100);
        }
        Console.ReadKey();
    }    
          
