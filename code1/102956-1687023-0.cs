    static void Main()
    { 
         string matchRegex = "......";
         string replaceExpression = "......";
         string pattern = "*.*";
         using ( DirectoryInfo di = new DirectoryInfo(.) )
         {
              foreach (FileInfo fi in di.GetFiles(pattern))
              {
                   using ( StreamReader sr = fi.OpenText() )
                   {
                        // Going from memory here, may need to use a TextReader...
                        string content = fi.ReadToEnd();
                        string newContent = Regex.Replace(content, matchRegex, replaceExpression);
                        // Write-out/overwirte your new file here....
                   }
              }
         }
    }
