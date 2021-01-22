    public static string ReduceIndent(this string line, int level)
    {
       var unindentedChars = line.SkipWhile((c, index) => char.IsWhiteSpace(c) && index < level);
       return new string(unindentedChars.ToArray());
    }
    
    public static string LineTransform(this string text, Func<string,string> transform)
    {
       var lines = text.Split(Enivironment.NewLine.ToCharArray())
                       .Select(transform);
    
       return string.Join(Environment.NewLine, lines.ToArray());
    }
    
    
    ...
    
    if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift && e.Key == Key.Tab)
    {                             
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
