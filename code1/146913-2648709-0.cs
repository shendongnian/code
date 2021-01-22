    foreach (Control ctrl in control.Controls)
    {
        ITextControl text = ctrl as ITextControl;
        if (text != null)
        {
            // now you can use the "Text" property in here,
            // regardless of the type of the control.
        }
    }
