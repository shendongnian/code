    private bool IsValidata()
    {
    
                //validate the First Name textbox
                if (!IsPresent(txtFirst, "First Name"))
                {
                    return false;
                }
                if (!StringValidator(Fname))
                {
                    return false;
                }           
    
                //validate the Last Name textbox
                if (!IsPresent(txtLast, "Last Name"))
                {
                    return false;
                }
                if (!StringValidator(Lname))
                {
                    return false;
                }
    
                return true;
    }
