    TextPointer startPos = rtb.Document.ContentStart.GetPositionAtOffset(searchWordIndex, LogicalDirection.Forward);
    startPos = startPos.CorrectPosition(searchWord, FindDialog.IsCaseSensitive);
    if (startPos != null)
    {
        TextPointer endPos = startPos.GetPositionAtOffset(textLength, LogicalDirection.Forward);
        if (endPos != null)
        {
             rtb.Selection.Select(startPos, endPos);
        }
    }
    public static TextPointer CorrectPosition(this TextPointer position, string word, bool caseSensitive)
    {
       TextPointer start = null;
       while (position != null)
       {
           if (position.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
           {
               string textRun = position.GetTextInRun(LogicalDirection.Forward);
               int indexInRun = textRun.IndexOf(word, caseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase);
               if (indexInRun >= 0)
               {
                   start = position.GetPositionAtOffset(indexInRun);
                   break;
               }
           }
           position = position.GetNextContextPosition(LogicalDirection.Forward);
       }
       return start; 
    }
