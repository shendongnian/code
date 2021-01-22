    bool Visible
    {
        get
        {
            bool b;
            Boolean.TryPase(this.Request["visible"], out b)
            return b;
        }
    }
