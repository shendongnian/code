    private int? bar;
    public int Bar
    {
        get
        {
            if (bar == null && innerFoo != null)
               bar = innerFoo.GetBar();
            return bar ?? 0;           
        }
        set
        {
            bar = value;
        }
    }
