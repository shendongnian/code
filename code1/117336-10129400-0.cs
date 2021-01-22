    private string getHTMLString()
    {
        DirectoryInfo di = new DirectoryInfo("some directory");
        FileInfo[] files = di.GetFiles("*.dll", SearchOption.AllDirectories);
            
        var table = new Table();
        foreach (FileInfo file in files)
        {
            Assembly assembly = Assembly.LoadFile(file.FullName);
            string version = assembly.GetName().Version.ToString();
            table.Add(new Tr { new Td { file.FullName }, new Td { version } });
        }
        return table.Render();
    }
