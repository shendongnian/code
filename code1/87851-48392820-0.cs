    using (var reader = new ChoCSVReader("emp.csv").WithFirstLineHeader())
    {
       foreach (dynamic item in reader)
       {
          Console.WriteLine(item.Id);
          Console.WriteLine(item.Name);
       }
    }
