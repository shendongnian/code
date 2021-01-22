    Array personNames = Array.CreateInstance(typeof (string), 3);
    // or Array personNames = new string[3];
    personNames.SetValue("Ally", 0);
    personNames.SetValue("Eloise", 1);
    personNames.SetValue("John", 2);
    string[] names = (string[]) personNames; 
    // or string[] names = personNames as string[]
    foreach (string name in names)
      Console.WriteLine(name);
