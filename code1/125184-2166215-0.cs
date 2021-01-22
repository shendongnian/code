    StringBuilder sb = new StringBuilder();
    sb.AppendLine("<html>");
    sb.AppendLine("<head>");
    sb.AppendLine("<title>Index of c:\\dir</title>");
    sb.AppendLine("</head>");
    sb.AppendLine("<body>");
    sb.AppendLine("<ul>");
    string[] filePaths = Directory.GetFiles(@"c:\dir");
    for (int i = 0; i < filePaths.Length; ++i) {
        string name = Path.GetFileName(filePaths[i]);
        sb.AppendLine("<li><a href=\"{0}\">{1}</a></li>",
            HttpUtility.HtmlEncode(HttpUtility.UrlEncode(name)),
            HttpUtility.HtmlEncode(name));
    }
    sb.AppendLine("</ul>");
    sb.AppendLine("</body>");
    sb.AppendLine("</html>");
    string result = sb.ToString();
