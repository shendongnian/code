    protected void Page_Load()
    {
        if(PreviousPage != null && PreviousPage is Page1)
        {
            if(((Page1)PreviousPage).xChecked)
            {
                //use xChecked like this
            }
        }
    }
