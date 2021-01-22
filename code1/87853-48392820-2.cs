    using (var reader = new ChoCSVReader<Employee>("emp.csv").WithFirstLineHeader())
    {
       foreach (var item in reader)
       {
          Console.WriteLine(item.Id);
          Console.WriteLine(item.Name);
       }
    }
