    public static void WriteToFile(string Path, string Text)
    {
        string content = File.ReadAllText(Path);
        content = Text + "\n" + content;      
        File.WriteAllText(Path, content);
    }
