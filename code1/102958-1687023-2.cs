    static void Main()
    { 
         // Remove everything (by commenting out) everything between HTML
         // and the end of the HEAD tag.
         string matchRegex = "&lt;html[^&gt;]*&gt;(.*?)&lt;/head&gt;";
         string replaceExpression = "&lt;html&gt; &gt;!-- \0 &lt;/head&gt; --&lt;";
         string pattern = "*.html";
         using ( DirectoryInfo di = new DirectoryInfo(.) )
         {
              foreach (FileInfo fi in di.GetFiles(pattern))
              {
                   using ( StreamReader sr = fi.OpenText() )
                   {
                        // Going from memory here, may need to use a TextReader...
                        string content = fi.ReadToEnd();
                        // Treat as single-line so that the match can span
                        // several lines.
                        string newContent = Regex.Replace(content, 
                                                          matchRegex, 
                                                          replaceExpression,
                                                          RegexOptions.Singleline);
                        // Write-out/overwirte your new file here....
                   }
              }
         }
    }
