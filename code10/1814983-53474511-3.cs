    Control _textbox = GetTextBox();
    _textbox.Tag = "custom tag name";
    grid.Children.Add(_textbox);
    Grid.SetRow(_textbox, row);
    public Control GetControl(){
        Control _textbox;
        if (condition1) {
          _textbox = GetTextBox();
        }
        else if (condition2) {
          _textbox = new AutoSuggestBox();
        }
        return _textbox;
    }
    
    public TextBox GetTextBox(){
    	TextBox _textbox = new TextBox();
        _textbox.Text = "text";
    	return _textbox;
    }
