        string linesFromFile = string.Empty;
        
        // Read into string from file
        using (StreamReader sr = new StreamReader("filename.txt"))
        {
            linesFromFile = sr.ReadToEnd();
            linesFromFile = linesFromFile.Replace(Environment.NewLine, ",");
            Console.WriteLine(linesFromFile);
        }
        // Write back from string to file
        using (StreamWriter sw = new StreamWriter("newFilename.txt"))
        {
            foreach(string s in linesFromFile.Split(','))
            {
                sw.WriteLine(s);
            }
        }
