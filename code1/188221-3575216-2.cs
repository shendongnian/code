    public static class StringExtensions
    {
     // Removes leading white-spaces in a string up to a maximum
     // of 'level' characters
     public static string ReduceIndent(this string line, int level)
     { 
       // Produces an IEnumerable<char> with the characters 
       // of the string verbatim, other than leading white-spaces
       var unindentedChars = line.SkipWhile((c, index) => char.IsWhiteSpace(c) && index < level);
           
       return new string(unindentedChars.ToArray());
     }
        
        
     // Applies a transformation to each line of a string and returns the
     // transformed string
     public static string LineTransform(this string text, Func<string,string> transform)
     {
       //Splits the string into an array of lines
       var lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
           
       //Applies the transformation to each line
       var transformedLines = lines.Select(transform);
        
       //Joins the transformed lines into a new string
       return string.Join(Environment.NewLine, transformedLines.ToArray());
     } 
    }
     ... 
    
    if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift && e.Key == Key.Tab)
    {                             
      // Reduces the indent level of the selected text by applying the
      // 'ReduceIndent' transformation to each line of the text.
      string replacement = txtEditor.SelectedText
                                    .LineTransform(line => line.ReduceIndent(4));
        
      int selStart = txtEditor.SelectionStart;
      int selLength = txtEditor.SelectionLength;
        
      txtEditor.Text = txtEditor.Text
                                .Remove(selStart, selLength)
                                .Insert(selStart, replacement);
        
      txtEditor.SelectionStart = selStart;
      txtEditor.SelectionLength = replacement.Length;
      e.Handled = true;
    }   
