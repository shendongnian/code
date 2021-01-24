    public int x
    {
        get { return x; }
        set
        {
            x = value; // <-- see you are assigning `value` to your `x` property.
            onPointeChanged();
        }
    }
