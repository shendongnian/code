    private static EventHandler _event;
    public static void SetEnterEvent(this System.Windows.Forms.Layout.ArrangedElementCollection theCollection, EventHandler theEvent)
    {
        _event = theEvent;
        recurseSetEnter(theCollection);
    }
