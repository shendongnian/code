    // Get starting pointer
    TextPointer navigator = flowDocument.ContentStart;
    // While we are not at end of document
    while (navigator.CompareTo(flowDocument.ContentEnd) < 0)
    {
        // Get text pointer context
        TextPointerContext context = navigator.GetPointerContext(LogicalDirection.Backward);
        // Get parent as run
        Run run = navigator.Parent as Run;
        // If start of text element within run
        if (context == TextPointerContext.ElementStart && run != null)
        {
            // Get text of run
            string runText = run.Text;
            // ToDo: Parse run text
        }
        // Get next text pointer
        navigator = navigator.GetNextContextPosition(LogicalDirection.Forward);
    }
