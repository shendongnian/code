    public string Password
    {
        get
        {
            return(textbox1.Text);
        }
        set
        {
            textbox1.Text = value;
            Changed = false;
        }
    }
