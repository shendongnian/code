        private void SelectText(int start, int length)
        {
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            TextPointer pointerStart = textRange.Start.GetPositionAtOffset(start, LogicalDirection.Forward);
            TextPointer pointerEnd = textRange.Start.GetPositionAtOffset(start + length, LogicalDirection.Backward);
            
            richTextBox.Selection.Select(pointerStart, pointerEnd);
        }
