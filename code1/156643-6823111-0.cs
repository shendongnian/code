    IWpfTextViewHost GetCurrentViewHost()
    {
        // code to get access to the editor's currently selected text cribbed from
        // http://msdn.microsoft.com/en-us/library/dd884850.aspx
        IVsTextManager txtMgr = (IVsTextManager)GetService(typeof(SVsTextManager));
        IVsTextView vTextView = null;
        int mustHaveFocus = 1;
        txtMgr.GetActiveView(mustHaveFocus, null, out vTextView);
        IVsUserData userData = vTextView as IVsUserData;
        if (userData == null)
        {
            return null;
        }
        else
        {
            IWpfTextViewHost viewHost;
            object holder;
            Guid guidViewHost = DefGuidList.guidIWpfTextViewHost;
            userData.GetData(ref guidViewHost, out holder);
            viewHost = (IWpfTextViewHost)holder;
            return viewHost;
        }
    }
    /// Given an IWpfTextViewHost representing the currently selected editor pane,
    /// return the ITextDocument for that view. That's useful for learning things 
    /// like the filename of the document, its creation date, and so on.
    ITextDocument GetTextDocumentForView( IWpfTextViewHost viewHost )
    {
        ITextDocument document;
        viewHost.TextView.TextDataModel.DocumentBuffer.Properties.TryGetProperty(typeof(ITextDocument), out document);
        return document;
    }
    /// Get the current editor selection
    ITextSelection GetSelection( IWpfTextViewHost viewHost )
    {
        return viewHost.TextView.Selection;
    }
