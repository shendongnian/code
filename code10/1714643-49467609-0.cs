    HashSet<string> names = new HashSet<string>();
    var lines = File.ReadAllLines("Users.txt");
    foreach(string line in lines)
    {
        string name = line.Split('#')[0];
        if(!names.Contains(name))
           names.Add(name);
    }
