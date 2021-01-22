    CheckBox MasterCheckbox;
    CheckBox ChildCheckbox;
    
    private void checkGridViewChkBox()
    {
        int i;
        int x = GridView1.Rows.Count;
        for (i = 0; i < x; i++)   //loop through rows
        {
            findControls(i);
            if (MasterCheckbox.Checked)
            {
               ChildCheckbox.Enabled = true;
            }else{		
			ChildCheckbox.Enabled = false;		
			}      
        }
         
    }
	
    private void findControls(int i)
    {                                                               
        MasterCheckbox = (CheckBox)(GridView1.Rows[i].FindControl("MasterCheckbox"));
        ChildCheckbox = (CheckBox)(GridView1.Rows[i].FindControl("ChildCheckbox")); 
    }
