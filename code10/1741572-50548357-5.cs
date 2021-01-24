    // Create some data
    var dictionary = new Dictionary<DateTime, int>();
    dictionary.Add(DateTime.Now.AddDays(-10), 34);
    dictionary.Add(DateTime.Now.AddDays(-5), 234);
    dictionary.Add(DateTime.Now.AddDays(-2), 345);
    dictionary.Add(DateTime.Now, 434);
    
    // Example using sum
    var sum = dictionary.Where(x => x.Key > DateTime.Now.AddDays(-6) && x.Key < DateTime.Now.AddDays(-1))
                .Sum(x => x.Value);
    
    Console.WriteLine(sum);
    
    // write to file
    using (var fileStrem = new FileStream(@"D:\dict.dat", FileMode.Create))
    {
       Serialize(dictionary, fileStrem);
    }
    // Read from file 
    using (var fileStrem = new FileStream(@"D:\dict.dat", FileMode.Open))
    {
       dictionary = Deserialize(fileStrem);
    }
    
    // sanity check
    sum = dictionary.Where(x => x.Key > DateTime.Now.AddDays(-6) && x.Key < DateTime.Now.AddDays(-1))
                      .Sum(x => x.Value);
    
    
    Console.WriteLine(sum);
