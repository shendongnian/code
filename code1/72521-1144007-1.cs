     protected void register_checked(object sender, EventArgs e)
            {
                //make sure you have a list
                if(Session["dic"] == null)
                    return;
                
                List<Test1> _dic =  (List<Test1>)Session["dic"];
                RadioButton btn = sender as RadioButton;
                string btnClientId = btn.ClientID;
    
                //make sure cast didnt crash
                if (btn == null)
                    return;
    
                foreach (DataGridItem control in dg1.Items)
                {
                    //find the register RadioButton, ID="register"
                    var item = control.FindControl("register");
                    //make sure its the right RadioButton
                    if (item.ClientID.Equals(btnClientId))
                    {
                        //get the item index of this DataGridItem and take the appropriate object for List<Test1>
                        Test1 realItem = _dic[control.ItemIndex] as Test1;
                        if (realItem == null)
                            continue;
    
                        //set the Items IsRegister to the button value.
                        realItem.IsRegister = btn.Checked;
                    }
                }
                
            }
