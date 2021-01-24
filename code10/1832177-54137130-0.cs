    private bool IsValid()
    {
        bool validation = true;
        foreach (Control ctl in this.Controls)
        {
            if (ctl is TextBox)
            {
                TextBox tb = ctl as TextBox;
                IsNumber(tb); 
                if (IsNumber(tb) == false)
                {
                    validation = false;
                    break;
                }
            } 
        }
        return validation;
    }
