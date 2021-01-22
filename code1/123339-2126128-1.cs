    Dictionary<string, int> counts = new Dictionary<string, int>();
    foreach (string name in arrName) {
       int count;
       if (counts.TryGetValue(name, out count)) {
          counts[name] = count + 1;
       } else {
          counts.Add(name, 1);
       }
    }
    // and then look for the most popular value:
    
    string mostPopular;
    int max = 0;
    foreach (string name in counts.Keys) {
       int count = counts[name];
       if (count > max) {
           mostPopular = name;
           max = count;
       }
    }
    
    // print it
    Console.Write("Most popular value: {0}", mostPopular);
