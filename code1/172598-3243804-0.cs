    string appDataFolder = Environment.GetFolderPath(
        Environment.SpecialFolder.ApplicationData
    );
    string filePath = Path.Combine(appDataFolder, "test.txt");
    string line;
    using (var reader = new StreamReader(filePath))
    while ((line = reader.ReadLine()) != null)
    {
        Console.WriteLine(line);
    }
