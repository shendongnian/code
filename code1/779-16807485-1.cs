    public class NumericTextBox : TextBox
    {
    	public NumericTextBox()
    	{
    		DataObject.AddPastingHandler(this, OnPaste);
    	}
    
    	private void OnPaste(object sender, DataObjectPastingEventArgs dataObjectPastingEventArgs)
    	{
    		var isText = dataObjectPastingEventArgs.SourceDataObject.GetDataPresent(System.Windows.DataFormats.Text, true);
    		if (isText)
    		{
    			var text = dataObjectPastingEventArgs.SourceDataObject.GetData(DataFormats.Text) as string;
    			if (IsTextValid(text))
    			{
    				return;
    			}
    		}
    		dataObjectPastingEventArgs.CancelCommand();
    	}
    
    	private bool IsTextValid(string enteredText)
    	{
    		if (!enteredText.All(c => Char.IsNumber(c) || c == '.' || c == '-'))
    		{
    			return false;
    		}
    
    		//We only validation against unselected text since the selected text will be replaced by the entered text
            var unselectedText = this.Text.Remove(SelectionStart, SelectionLength);
            if (enteredText == "." && unselectedText.Contains("."))
            {
                return false;
            }
            if (enteredText == "-" && unselectedText.Length > 0)
            {
                return false;
            }
    
    		return true;
    	}
    
    	protected override void OnPreviewTextInput(System.Windows.Input.TextCompositionEventArgs e)
    	{
    		e.Handled = !IsTextValid(e.Text);
    		base.OnPreviewTextInput(e);
    	}
    }
