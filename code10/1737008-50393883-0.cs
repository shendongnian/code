    string[] lines = System.IO.File.ReadAllLines(caminho);
    
    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(caminho))
    {
        foreach (string line in lines)
        {
            if (!line.Contains(listView1.SelectedIndices[0].ToString()))
            {
                writer.WriteLine(line);
            }
        }
    }
