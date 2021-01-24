        //Reads the text file
        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
        {
            //Adds the content of each line to a list
            string line = string.Empty;
            while ((line = streamReader.ReadAllLines()) != null)
            {
                destinationEmails.Add(line);
            }
        }
