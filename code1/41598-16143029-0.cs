    private Something something;
    public Something Something
    {
        get
        {
            return something ?? (something = new Something());
        }
    }
