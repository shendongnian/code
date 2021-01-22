    public static void recurseSetEnter(ArrangedElementCollection aCollection)
    {
        foreach (Control theControl in aCollection)
        {
            // edit : you may wish to add a "filter" here for "inner controls"
            // like those exposed by the 'NumericUpDown control, for example,
            // that you are almost certainly not going to want to assign an
            // an event handler to : like this :
            if (! String.IsNullOrWhiteSpace(theControl.Name))theControl.Enter += _event;
            // end edit
            if (theControl.Controls.Count > 0) recurseSetEnter(theControl.Controls);
        }
    }
