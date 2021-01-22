    TextRange FindWordFromPosition(TextPointer position, string word)
    {
        while (position != null)
        {
            if (position.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
            {
                string textRun = position.GetTextInRun(LogicalDirection.Forward);
                // Find the starting index of any substring that matches "word".
                int indexInRun = textRun.IndexOf(word);
                if (indexInRun >= 0)
                {
                    TextPointer start = position.GetPositionAtOffset(indexInRun);
                    TextPointer end = start.GetPositionAtOffset(word.Length);
                    return new TextRange(start, end);
                }
            }
                
            position = position.GetNextContextPosition(LogicalDirection.Forward);
        }
        // position will be null if "word" is not found.
        return null;
    }
