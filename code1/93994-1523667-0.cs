    var people = File.ReadAllLines("filename"))
        .Select(line => { 
           var parts = line.Split();
           return new Person { 
               Name = parts[0],
               Password = parts[1],
               Email = parts[2]
           });
