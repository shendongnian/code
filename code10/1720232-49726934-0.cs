    if (!File.Exists(filePath))
    {
        MessageBox.Show($"File \"{filePath}\" not found");
    }
    else
    {
        filePath = filePath.Replace("\n", String.Empty);
        filePath = filePath.Replace("\r", String.Empty);
        filePath = filePath.Replace("\t", String.Empty);
        StreamReader sr = new StreamReader(filePath);
        string line = sr.ReadLine();
        sr.Close();
        txtFakeBox.Text = line;
    }
