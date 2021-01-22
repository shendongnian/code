    String imgPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()) + "\\PW.gif"; 
    StringBuilder sb = new StringBuilder();
    sb.Append("<html><body>");
    sb.Append("<img src = \"file:" + imgPath + "\">");
    sb.Append("</body></html>");
    webBrowser1.DocumentText = sb.ToString();
