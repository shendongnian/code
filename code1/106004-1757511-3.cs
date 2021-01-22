    public bool DoSearch(RichTextBox richTextBox, string searchText, bool searchNext)
    {
      TextRange searchRange;
      // Get the range to search
      if(searchNext)
        searchRange = new TextRange(
            richTextBox.Selection.Start.GetPositionAtOffset(1),
            richTextBox.Document.ContentEnd);
      else
        searchRange = new TextRange(
            richTextBox.Document.ContentStart,
            richTextBox.Document.ContentEnd);
      // Do the search
      TextRange foundRange = FindTextInRange(searchRange, searchText);
      if(foundRange==null)
        return false;
      // Select the found range
      richTextBox.Selection.Select(foundRange.Start, foundRange.End);
      return true; 
    }
    public TextRange FindTextInRange(TextRange searchRange, string searchText)
    {
      // Search the text with IndexOf
      int offset = searchRange.Text.IndexOf(searchText);
      if(offset<0)
        return false;  // Not found
      // Try to select the text as a contiguous range
      for(TextPointer start = searchRange.Start.GetPositionAtOffset(offset); start != searchRange.End; start = start.GetPositionAtOffset(1))
      {
        TextRange result = new TextRange(start, start.GetPositionAtOffset(searchText.Length);
        if(result.Text == searchText)
          return result;
      }
      return null;
    }
