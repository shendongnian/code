    // In Control1
    // Assuming Control2 is some sort of Save button, for example
    public EventHandler SaveClicked
    {
        add { control2.Click += value; }
        remove { control2.Click -= value; }
    }
