    private Thickness _padding;
    public Thickness Padding
    {
        get
        {
            return _padding;
        }
        set
        {
            if(Device.Idiom == TargetIdiom.Phone)
            {
                _padding = new Thickness (34.5);
            }
            if(Device.Idiom == TargetIdiom.Tablet)
            {
                _padding = new Thickness (54.5);
            }
        }
    }
