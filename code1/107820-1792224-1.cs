    public void ReadFile()
    {
        using (var file = new FileStream("c:\file.txt", FileMode.Open, FileAccess.Read))
        {
            txtFile.Text = new StreamReader(file).ReadToEnd();
        }
    }
