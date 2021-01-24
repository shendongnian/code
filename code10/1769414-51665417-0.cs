    try
    {
       var directory = Path.Combine(Environment.CurrentDirectory, $@"Status-Test{Guid.NewGuid()}");
       Console.WriteLine(directory);
    
       var di = Directory.CreateDirectory(directory);
    
       Console.WriteLine($"The directory was created successfully at {Directory.GetCreationTime(directory)}.");
       Console.WriteLine($"==> { di.FullName}");
    }
    catch (Exception e)
    {
       Console.WriteLine("Oh NOES!: {0}", e);
    }
