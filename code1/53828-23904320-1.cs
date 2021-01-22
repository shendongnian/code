    private void LoadTextDocument(string fileName, RichTextBox rtb)
    {
        System.IO.StreamReader objReader = new StreamReader(fileName);
            if (File.Exists(fileName))
            {
                rtb.AppendText(objReader.ReadToEnd());
            }
            else rtb.AppendText("ERROR: File not found!");
            objReader.Close();
    }
