    string appDataFolder = Environment.GetFolderPath(
        Environment.SpecialFolder.ApplicationData
    );
    string filePath = Path.Combine(appDataFolder, "test.txt");
    using (var reader = new StreamReader(filePath))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }
