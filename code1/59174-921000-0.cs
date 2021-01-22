    static void Main(string[] args)
    {
        string searchText = "find this text, and some other text";
        string replaceText = "replace with this text";
        string root = Path.GetPathRoot(Environment.SystemDirectory);
        string filePath = (root + "mytestfile.xml"); 
        string content = File.ReadAllText(filePath);
        content = content.Replace(searchText, replaceText);
        File.WriteAllText(filePath, content);  
    }
        
