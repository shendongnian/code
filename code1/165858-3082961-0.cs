    private void geterrors(Form f, List<string> errors)
    {
        foreach (Control c in f.Controls)
        {
            geterrors(c, errors);
    
        }
    }
    
    private void geterrors(Control c, List<string> errors)
    {
        if (errorProvider1.GetError(c).Length > 0)
        {
            errors.Add(errorProvider1.GetError(c));
    
            if (c.HasChildren)
            {
                geterrors(c, errors);
            }
        }
    }
