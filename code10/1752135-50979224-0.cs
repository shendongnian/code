    string[] lines = File.ReadAllLines(filePath);        
    foreach (string line in lines)
    {
        if (!string.IsNullOrWhitespace(line) && line.Split(',').Length > 3) 
        {
            Person person = ConvertStringToPerson(line);
            personList.Add(person);
        }
    }
