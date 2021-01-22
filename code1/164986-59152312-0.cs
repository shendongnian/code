    InitializeComponent();
    
                    // "DescriptionTextBox" is a TextBox
                    DataObject.AddPastingHandler(DescriptionTextBox, OnDescriptionPaste);
    private void OnDescriptionPaste(object sender, DataObjectPastingEventArgs e)
            {
                if (!e.SourceDataObject.GetDataPresent(DataFormats.UnicodeText, true))
                    return;
    
                var pastedText = e.SourceDataObject.GetData(DataFormats.UnicodeText) as string;
                if (string.IsNullOrEmpty(pastedText))
                    return;
    
                var txtBox = (TextBox) sender;
    
                var before = ""; //Text before pasted text
                var after = txtBox.Text; //Text after pasted text
    
                //Get before and after text
                if (txtBox.CaretIndex > 0)
                {
                    before = txtBox.Text.Substring(0, txtBox.CaretIndex);
                    after = txtBox.Text.Substring(txtBox.CaretIndex);
                }
                
                //Do custom logic for handling the pasted text.
                //Split sentences ending with . into new line.
                var parts = pastedText.Split(new []{'.'}, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 1)
                {
                    pastedText = parts.Select(x => x.Trim()).ToArray().ToStringX(".\r\n");
                    pastedText += ".";
                }
    
                var newCaretIndex = before.Length + pastedText.Length;
    
                e.CancelCommand(); //Cancels the paste, we do it manually
                txtBox.Text = $"{before}{pastedText}{after}"; //Set new text
                txtBox.CaretIndex = newCaretIndex; //Set new caret index
            }
