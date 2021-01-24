    public void WriteLine(string text)
    {
    	Paragraph para = new Paragraph();
    
    	//Split the content from text
    
    	var content = text.Split(':');
    
    	// Buffer output
    	para.Inlines.Add(new Run { Text = content[0] + ": ", Foreground = Brushes.Green, FontWeight = FontWeights.Bold });
    	para.Inlines.Add(new Run { Text = content[1], Foreground = Brushes.White, FontWeight = FontWeights.Regular });
    
    	// Add block
    	txtOutput.Document.Blocks.Add(para);
    
    	// Always keep scrolled to the end
    	txtOutput.ScrollToEnd();
    
    	//// Clear input field.
    	//txtInput.Clear();
    
    	//// Focus back on the input field.
    	//txtInput.Focus();
    }
