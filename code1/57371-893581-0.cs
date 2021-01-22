    private void Filter(string filename)
    {
        using (TextWriter writer = File.CreateText(Application.StartupPath + "\\temp\\test.txt"))
        {
            using(TextReader reader = File.OpenText(filename))
            {
                List<string> lines;
                string line;
                while((line = reader.ReadLine()) != null)
                    lines.Add(line);
                var query = from l in lines
                            let splitLine = l.Split('\t')
                            where int.Parse(splitLine.Skip(1).First()) == 24809
                            select l;
                foreach(var l in query)               
                    writer.WriteLine(l); 
            }
        }
    }
