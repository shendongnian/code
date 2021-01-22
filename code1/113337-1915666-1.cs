    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    
    public static void ReplaceInFile(
                          string filePath, string searchText, string replaceText )
    {
        using (StreamReader reader = new StreamReader( filePath ))
        {
            string content = reader.ReadToEnd();
            reader.Close();
        }
    
        content = Regex.Replace( content, searchText, replaceText );
    
        using (StreamWriter writer = new StreamWriter( filePath ))
        {
            writer.Write( content );
            writer.Close();
        }
    }
