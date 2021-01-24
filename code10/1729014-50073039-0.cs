        List<String[]> fileContent = new List<string[]>();
    
        using (StreamReader reader = new StreamReader(Server.MapPath("~/" + Path))) // mind the encoding - UTF8
        using (TextFieldParser parser = new TextFieldParser(reader))
        {
            parser.TrimWhiteSpace = true; // if you want
            parser.Delimiters = new[] { "," };
            parser.HasFieldsEnclosedInQuotes = true;
    
            while (!parser.EndOfData)
            {
                string[] line = parser.ReadFields();
                fileContent.Add(line);
                Console.WriteLine(line);
            }
        }
    }
