    private void Filter(string filename)
    {
        using (TextWriter writer = File.CreateText(Application.StartupPath + "\\temp\\test.txt"))
        {
            var lines = File.ReadAllLines(filename);
            var ints = from line in lines
                       let items = line.Split('\t')
                       let myInteger = int.Parse(items[1]);
                       where myInteger == 24809
                       select myInteger;
            
            foreach (var myInt in ints)
            {
                writer.WriteLine(line)
            }
        }
    }
