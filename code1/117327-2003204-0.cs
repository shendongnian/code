    private string getHTMLString()
    {
        DirectoryInfo di = new DirectoryInfo("some directory");
        FileInfo[] files = di.GetFiles("*.dll", SearchOption.AllDirectories);
        StringBuilder sb = new StringBuilder();
        sb.Append("<table>");
        foreach (FileInfo file in files)
        {
            Assembly assembly = Assembly.LoadFile(file.FullName);
            string version = assembly.GetName().Version.ToString();
            sb.AppendFormat("<tr><td>{0}</td><td>{1}</td></tr>", file.FullName, version);
        }
        sb.Append("</table>");
        return sb.ToString();
    
     }
