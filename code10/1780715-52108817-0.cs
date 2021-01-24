    InitializeComponent();
    
    var placeholder = myEditor.Text;
    
    myEditor.Focused += (sender, e) =>
    {
         // Set the editor's text empty on focus, only if the place 
         // holder is present
         if (myEditor.Text.Equals(placeholder))
         {
              myEditor.Text = string.Empty;
              // Here You can change the text color of editor as well
              // to active text color
         }
    };
    
    myEditor.Unfocused += (sender, e) => 
    {
         // Set the editor's text to place holder on unfocus, only if 
         // there is no data entered in editor
        if (string.IsNullOrEmpty(myEditor.Text.Trim()))
        {
            myEditor.Text = placeholder;
            // Here You can change the text color of editor as well
            // to dim text color (Text Hint Color)
        }
    };
