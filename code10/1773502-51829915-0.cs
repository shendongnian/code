    private void WriteDataToFile(string line)
    {
        string path = "Assets/Resources/test.txt";
        string[] text = string.empty;
        if(File.Exists(path))
        {
           text = File.ReadAllLines(path);
           if(!text.Contains(line))
              File.AppendAllText(path, Line);
        }
        
    }
