    static class DocumentHelper
    {
        static public string TextUpTo(this InlineCollection inlines, TextPointer pointer)
        {
            StringBuilder textUpTo = new StringBuilder();
            foreach (Inline inline in inlines) {
                if (inline.ElementStart.Offset > pointer.Offset) {
                    break;
                }
                if (inline is Run run) {
                    // Need some more work here to take account of run.FlowDirection and pointer.LogicalDirection.
                    textUpTo.Append(run.Text.Substring(0, Math.Max(0, Math.Min(run.Text.Length, pointer.Offset - run.ContentStart.Offset))));
                } else if (inline is Span span) {
                    string spanTextUpTo = span.Inlines.TextUpTo(pointer);
                    textUpTo.Append(spanTextUpTo);
                } else if (inline is LineBreak lineBreak) {
                    textUpTo.Append((pointer.Offset >= lineBreak.ContentEnd.Offset) ? Environment.NewLine : "");
                } else if (inline is InlineUIContainer uiContainer) {
                    textUpTo.Append(" "); // empty string replacing the UI content. 
                } else {
                    throw new InvalidOperationException($"Unrecognized inline type {inline.GetType().Name}");
                }
            }
            return textUpTo.ToString();
        }
        static public string TextUpTo( this RichTextBlock rtb, TextPointer pointer)
        {
            StringBuilder textUpTo = new StringBuilder();
            foreach (Block block in rtb.Blocks) {
                if (block is Paragraph paragraph) {
                    textUpTo.Append(paragraph.Inlines.TextUpTo( pointer)); 
                } else {
                    throw new InvalidOperationException($"Unrecognized block type {block.GetType().Name}");
                }
            }
            return textUpTo.ToString();
        }
    }
