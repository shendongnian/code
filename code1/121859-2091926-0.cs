    private void PopulateTextBoxWithFileContents(string path, TextBox textBox)
    {
        using (var fs = File.OpenRead(path))
        {
            using (var sr = new StreamReader(fs))
            {
                while (!sr.EndOfStream)
                    textBox.Text += sr.ReadLine();                        
                sr.Close();                    
            }
            fs.Close();
        }
    }
