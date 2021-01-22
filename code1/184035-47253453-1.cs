    using (var reader = new ChoCSVReader("test.csv").WithFirstLineHeader())
    {
       foreach (dynamic item in reader)
       {
          Console.WriteLine(item.Id);
          Console.WriteLine(item.Name);
       }
    }
