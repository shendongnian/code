    public static void WriteToFile(string path, string text)
    {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("a,b,c");
            stringBuilder.Append(File.ReadAllText(path)).AppendLine();
            File.WriteAllText(path, stringBuilder.ToString()); 
    }
