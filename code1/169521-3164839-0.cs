    DateTime dob = new DateTime();
    if (dob != null)    // dob can't be null unless you haven't instantiated it, 
                        // it's a value type. Actually it's 
                        // value here is always DateTime.MinValue, 
                        // since you aren't assigning anything to it.
    {
        if (dob <= new DateTime(2004, 01, 01) &&
            dob <= new DateTime(2005, 12, 31))    // this check is redundant.
                                                  // if this condition is ever evaluated,
                                                  // it will always be true. I assume you have
                                                  // mixed up your < and > signs here  
        {
            TextBox6.Text = "Group A";
    
        }
        else if (dob <= new DateTime(2003, 12, 31) &&  // as above, this statement can never
                                                       // evaluate to true. you won't even
                                                       // reach this code unless dob > 2004
                 dob <= new DateTime(2002, 01, 01))
        {
            TextBox6.Text = "Group B";
        }
    }
