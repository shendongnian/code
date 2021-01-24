    static void ShowObject(ModelNew obj)
    {
        Console.WriteLine("Id: " + obj.Id);
        foreach (var op in obj.Options)
        {
            Console.WriteLine("Id: " + op.Id);
            Console.WriteLine("Name: " + op.Name);
        }
    }
