    private void richTB_GotMouseCapture(object sender, MouseEventArgs e)
    {
        string searchText = "text";
        TextPointer pointer = richTB.Document.ContentStart;
        while (pointer != null)
        {
            if (pointer.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
            {
                string textRun = pointer.GetTextInRun(LogicalDirection.Forward);
                // where textRun is the text in the flowDocument
                // and searchText is the text that is being searched for
                int indexInRun = textRun.IndexOf(searchText);
                if (indexInRun >= 0)
                {
                    TextPointer startPos = pointer.GetPositionAtOffset(indexInRun);
                    TextPointer endPos = pointer.GetPositionAtOffset(indexInRun + searchText.Length);
                    richTB.Selection.Select(startPos, endPos);
                    break;
                }
            }
            pointer = pointer.GetNextContextPosition(LogicalDirection.Forward);
        }
    }
