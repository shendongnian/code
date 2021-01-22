    bool Visible
    {
        get
        {
            bool b;
            Boolean.TryParse(this.Request["visible"], out b)
            return b;
        }
    }
