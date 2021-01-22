    //Popullate listItems from your ListBox     
    var listItems = new string[] { "Apple", "Orange", "Pineapple" };
    var writers = new StreamWriter[listItems.Length];
    for (int i = 0; i < listItems.Length; i++)
    {
        writers[i] = File.CreateText(listItems[i] + ".txt");
    }
    var reader = new StreamReader(File.OpenRead(bigFatFile));
    
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        for (int i = 0; i < listItems.Length; i++)
        {
            if (line.StartsWith(listItems[i]))
                writers[i].WriteLine(line);
        }
    }
    reader.Close();
    foreach (var writer in writers)
        writer.Close();
