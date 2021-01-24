    foreach (string line in File.ReadLines(filePath))
    {
        if (!string.IsNullOrWhitespace(line)) 
        {
            Person person = ConvertStringToPerson(line);
            personList.Add(person);
        }
    }
