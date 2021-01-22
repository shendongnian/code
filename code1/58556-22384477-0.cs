    // When set to a Regex, the TextBox will only accept characters that match the RegEx
    
    /// <summary>
    /// Lets you enter a RegexPattern of what characters are allowed as input in a TextBox
    /// </summary>
    public static readonly DependencyProperty AllowedCharactersRegexProperty =
        DependencyProperty.RegisterAttached("AllowedCharactersRegex",
                                            typeof(string), typeof(TextBoxProperties),
                                            new UIPropertyMetadata(null, AllowedCharactersRegexChanged));
    
    // Get
    public static string GetAllowedCharactersRegex(DependencyObject obj)
    {
        return (string)obj.GetValue(AllowedCharactersRegexProperty);
    }
    
    // Set
    public static void SetAllowedCharactersRegex(DependencyObject obj, string value)
    {
        obj.SetValue(AllowedCharactersRegexProperty, value);
    }
    
    // Events
    public static void AllowedCharactersRegexChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        var tb = obj as TextBox;
        if (tb != null)
        {
            if (e.NewValue != null)
            {
                tb.PreviewTextInput += Textbox_PreviewTextChanged;
                DataObject.AddPastingHandler(tb, TextBox_OnPaste);
            }
            else
            {
                tb.PreviewTextInput -= Textbox_PreviewTextChanged;
                DataObject.RemovePastingHandler(tb, TextBox_OnPaste);
            }
        }
    }
    
    public static void TextBox_OnPaste(object sender, DataObjectPastingEventArgs e)
    {
        var tb = sender as TextBox;
    
        bool isText = e.SourceDataObject.GetDataPresent(DataFormats.Text, true);
        if (!isText) return;
    
        var newText = e.SourceDataObject.GetData(DataFormats.Text) as string;
        string re = GetAllowedCharactersRegex(tb);
        re = string.Format("[^{0}]", re);
    
        if (Regex.IsMatch(newText.Trim(), re, RegexOptions.IgnoreCase))
        {
            e.CancelCommand();
        }
    }
    
    public static void Textbox_PreviewTextChanged(object sender, TextCompositionEventArgs e)
    {
        var tb = sender as TextBox;
        if (tb != null)
        {
            string re = GetAllowedCharactersRegex(tb);
            re = string.Format("[^{0}]", re);
    
            if (Regex.IsMatch(e.Text, re, RegexOptions.IgnoreCase))
            {
                e.Handled = true;
            }
        }
    }
