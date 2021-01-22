    _textBox.TextChanged += delegate(System.Object o, System.EventArgs e)
    {
        TextBox _tbox = o as TextBox;
        _tbox.Text = new string(_tbox.Text.Where(c => (char.IsDigit(c)) || (c == '.')).ToArray());
    };
