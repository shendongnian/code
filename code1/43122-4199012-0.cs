        public static void SetFontSize(RichTextBox target, double value)
        {
            // Make sure we have a richtextbox.
            if (target == null)
                return;
            // Make sure we have a selection. Should have one even if there is no text selected.
            if (target.Selection != null)
            {
                // Check whether there is text selected or just sitting at cursor
                if (target.Selection.IsEmpty)
                {
                    // Check to see if we are at the start of the textbox and nothing has been added yet
                    if (target.Selection.Start.Paragraph == null)
                    {
                        // Add a new paragraph object to the richtextbox with the fontsize
                        Paragraph p = new Paragraph();
                        p.FontSize = value;
                        target.Document.Blocks.Add(p);
                    }
                    else
                    {
                        // Get current position of cursor
                        TextPointer curCaret = target.CaretPosition;
                        // Get the current block object that the cursor is in
                        Block curBlock = target.Document.Blocks.Where
                            (x => x.ContentStart.CompareTo(curCaret) == -1 && x.ContentEnd.CompareTo(curCaret) == 1).FirstOrDefault();
                        if (curBlock != null)
                        {
                            Paragraph curParagraph = curBlock as Paragraph;
                            // Create a new run object with the fontsize, and add it to the current block
                            Run newRun = new Run();
                            newRun.FontSize = value;
                            curParagraph.Inlines.Add(newRun);
                            // Reset the cursor into the new block. 
                            // If we don't do this, the font size will default again when you start typing.
                            target.CaretPosition = newRun.ElementStart;
                        }
                    }
                }
                else // There is selected text, so change the fontsize of the selection
                {
                    TextRange selectionTextRange = new TextRange(target.Selection.Start, target.Selection.End);
                    selectionTextRange.ApplyPropertyValue(TextElement.FontSizeProperty, value);
                }
            }
            // Reset the focus onto the richtextbox after selecting the font in a toolbar etc
            target.Focus();
        }
