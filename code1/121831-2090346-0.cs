    Hyperlink hlink = new Hyperlink(new Run("here"));
    hlink.Click += SomeEventHandler;  // event handler to open text file
    hintInfo.Inlines.Clear();
    hintInfo.Inlines.Add("Click ");
    hintInfo.Inlines.Add(hlink);
    hintInfo.Inlines.Add(" to see more info.");
