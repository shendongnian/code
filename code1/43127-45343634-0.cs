    protected override void OnTextInput(TextCompositionEventArgs e)
    {
        TextRange range = new TextRange(this.Selection.Start, this.Selection.End);
        // Doesn't matter whether the selection is empty or not, it should be 
        // replaced with something new, and with the right formatting
        range = e.Text;
        
        // Now nothing else would get affected...
        range.ApplyPropertyValue(TextElement.FontFamilyProperty, value);
        this.CaretPosition = range.End;
        e.Handled = true; // You might not need this line :)
    }
