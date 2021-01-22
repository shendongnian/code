        var query = from line in new LineReader(filename)
                    let items = line.Split('\t')
                    let myInteger int.Parse(items[1]);
                    where myInteger == 24809
                    select line;
        using (TextWriter writer = File.CreateText(Application.StartupPath 
                                                   + "\\temp\\test.txt"))
        {
            foreach (string line in query)
            {
                writer.WriteLine(line);
            }
        }
