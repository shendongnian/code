    foreach(Button c in Form.Controls){
    
    if (pingx.Status == IPStatus.Success)
    
    {
        c.BackColor = Color.Green;
    }
    else
    {
         c.BackColor = Color.Red;
    }
    
    }
