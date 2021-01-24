    private decimal gPA;
    public decimal GPA
    {
        get
        {
            return gPA;
        }
        set
        {
            if (value <= 0)  // use value, not gPA here
            {
                gPA = 0;
            }
            else if (value >= 4)
            {
                gPA = 4;
            }
            else
            {
                gPA = value; 
            }
        }
    }
