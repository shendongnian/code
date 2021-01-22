    public void TextViewCreated(IWpfTextView textView)
    {
        var dte = GlobalServiceProvider.GetService(typeof(DTE)) as DTE;
        textView.TextBuffer.Changed += (sender, args) =>
        {
            //Output window is friendly and writes full lines at a time, so we only need to look at the changed text.
            foreach (var change in args.Changes)
            {
                string text = args.After.GetText(change.NewSpan);
                if (BuildError.IsMatch(text))
                    dte.ExecuteCommand("Build.Cancel");
            };
        }
    }
