    using (FileStream output = 
        new FileStream("C:\\peoplearray.dat", FileMode.CreateNew))
    {
        BinaryFormatter bformatter = new BinaryFormatter();
        bformatter.Serialize(output, 
                             new Person[] {
                                 new Person{Firstname="Alex"}
                             });
    }
    using (FileStream input = 
          new FileStream("C:\\peoplearray.dat", FileMode.Open))
    {
        BinaryFormatter bformatter = new BinaryFormatter();
        var results = bformatter.Deserialize(input) as Person[];
        foreach (Person p in results)
        {
            Console.WriteLine(p.Firstname);
        }
    }
