    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    static public void ReplaceInFile( string filePath, string searchText, string replaceText )
    {
        StreamReader reader = new StreamReader( filePath );
        string content = reader.ReadToEnd();
        reader.Close();
    
        content = Regex.Replace( content, searchText, replaceText );
    
        StreamWriter writer = new StreamWriter( filePath );
        writer.Write( content );
        writer.Close();
    }
