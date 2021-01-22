    /// <summary>
    /// Gets the text pointer at the given character offset.
    /// Each line break will count as 2 chars.
    /// </summary>
    /// <param name="richTextBox">The rich text box.</param>
    /// <param name="offset">The offset.</param>
    /// <returns>The TextPointer at the given character offset</returns>
    public static TextPointer GetTextPointerAtOffset(this RichTextBox richTextBox, int offset)
    {
    	var navigator = richTextBox.Document.ContentStart;
    	int cnt = 0;
    
    	while (navigator.CompareTo(richTextBox.Document.ContentEnd) < 0)
    	{
    		switch (navigator.GetPointerContext(LogicalDirection.Forward))
    		{
    			case TextPointerContext.ElementStart:
    				break;
    			case TextPointerContext.ElementEnd:
    				if (navigator.GetAdjacentElement(LogicalDirection.Forward) is Paragraph)
    					cnt += 2;
    				break;
    			case TextPointerContext.EmbeddedElement:
    				// TODO: Find out what to do here?
    				cnt++;
    				break;
    			case TextPointerContext.Text:
    				int runLength = navigator.GetTextRunLength(LogicalDirection.Forward);
    
    				if (runLength > 0 && runLength + cnt < offset)
    				{
    					cnt += runLength;
    					navigator = navigator.GetPositionAtOffset(runLength);
    					if (cnt > offset)
    						break;
    					continue;
    				}
    				cnt++;
    				break;
    		}
    
    		if (cnt > offset)
    			break;
    
    		navigator = navigator.GetPositionAtOffset(1, LogicalDirection.Forward);
    
    	} // End while.
    
    	return navigator;
    }
