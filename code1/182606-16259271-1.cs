    public TextEditorForm()
    {
        InitializeComponent();
        AddNewTextEditor("New file");
        SetSyntaxHighlighting("Mathematica");    
        editor.ActiveTextAreaControl.TextEditorProperties.IndentationSize = 0;
        editor.ActiveTextAreaControl.ShowScrollBars(Orientation.Vertical,false);
        editor.TextChanged += new EventHandler(editor_TextChanged);
    }
    
    void editor_TextChanged(object sender, EventArgs e)
    {            
        string[] lines = editor.Text.Split(new char[] { '\r', '\n' });
        bool isVisible = (lines.Length > editor.ActiveTextAreaControl.TextArea.TextView.VisibleLineCount);
        editor.ActiveTextAreaControl.ShowScrollBars(Orientation.Vertical, isVisible);               
    }
