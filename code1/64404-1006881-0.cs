    List<string> settings = new List<string>();
    using (TextReader reader = File.OpenText(fileName, Encoding.ASCII))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            settings.Add(line.Split(','));
        }
    }
    MessageBox.Show(settings[1][0]); // Shows the first part of the second line
