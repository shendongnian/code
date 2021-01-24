         public static void CommentStripper()
         {
             var text = @"/*This is some developer comment at the top of the file*/
    /*
     * $Log:
     *  1   Client Name 1.0   07/11/2012 16:28:54  Umair Khalid did something
     *  2   Client Name 1.0   07/11/2012 16:28:54  Umair Khalid again did 
     *                                             something
     * $
     */
    
    /*
        This is not a log entry
    */
    
    public class ABC
    {
      /*This is just a variable*/
      int a = 0;
      public int method1()
      {
      }
    }";
        //this next line could be File.ReadAllLines to get the text from a file
        var lines = text.Split(new[] {"\r\n"}, StringSplitOptions.None);
    
        var buffer = new StringBuilder();
        ParseState parseState = ParseState.Normal;
        string lastLine = string.Empty;
    
        foreach (var line in lines)
        {
            if (parseState == ParseState.Normal)
            {
                if (line == "/*")
                {
                    lastLine = line;
                    parseState = ParseState.MayBeInMultiLineComment;
                }
                else
                {
                    buffer.AppendLine(line);
                }
            }
            else if (parseState == ParseState.MayBeInMultiLineComment)
            {
                if (line == " * $Log:")
                {
                    parseState = ParseState.InMultilineComment;
                }
                else
                {
                    parseState = ParseState.Normal;
                    buffer.AppendLine(lastLine);
                    buffer.AppendLine(line);
                }
                lastLine = string.Empty;
            }
            else if (parseState == ParseState.InMultilineComment)
            {
                if (line == " */")
                {
                    parseState = ParseState.Normal;
                }
            }
    
        }
        //you could do what you want with the string, I'm just going to write it out to the debugger console.
        Debug.Write(buffer.ToString());
    }
