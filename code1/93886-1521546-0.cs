       using (StreamReader sr = new StreamReader("filename.txt"))
       {
            string linesFromFile = sr.ReadToEnd();
            linesFromFile = linesFromFile.Replace(Environment.NewLine, ",");
            Console.WriteLine(linesFromFile);
       }
