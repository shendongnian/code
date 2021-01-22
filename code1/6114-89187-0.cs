    Console.WriteLine(Settings.Default.PropertyValues.Count.ToString());
    Console.ReadLine();
    Settings.Default.Setting = "abc";
    Console.WriteLine(Settings.Default.PropertyValues.Count.ToString());
    Console.ReadLine();
