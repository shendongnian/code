    public void ReadFile()
    {
        using (FileStream file = new FileStream("c:\file.txt", FileMode.Open, FileAccess.Read))
        {
            using (StreamReader streamReader = new StreamReader(file))
            {
                txtFile.Text = streamReader.ReadToEnd();
            }
        }
    }
