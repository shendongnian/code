    using (var reader = new ChoCSVReader("test.csv").WithFirstLineHeader()
        .WithField('Field1')
        .WithField('Field2')
    )
    {
       foreach (dynamic item in reader)
       {
          Console.WriteLine(item.Field1);
          Console.WriteLine(item.Field2);
       }
    }
