    public static void recurseSetEnter(ArrangedElementCollection aCollection)
    {
        foreach (Control theControl in aCollection)
        {
            theControl.Enter += _event;
            if (theControl.Controls.Count > 0) recurseSetEnter(theControl.Controls);
        }
    }
