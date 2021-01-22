    public void Question1()
    {    
        CheckBox chkactive = item.FindControl("chkactive") as CheckBox;
        if (chkActive != null)    
           dmxdevice.Active = chkActive.Checked;
        else
           dmxdevice.Active = false;
    }
