    public Form()
    {
        InitializeComponents();
        
        if(userIsNotAdmin)
        {
            foreach (Control item in this.Controls)
            {
                if(item.Tag.ToString() == "Admin_C")
                    this.Controls.Remove(item); 
            }
        }
    }
