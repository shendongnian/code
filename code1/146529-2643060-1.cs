    List<List<string>> lls = new List<List<string>>();
    
    Button_Click()
    {
        List<string> str = new List<string>(); 
        for (int i = 0; i < sub.Count; i++) 
        { 
            if (checkbx[i].Checked == true) 
            { 
                str.Add(checkbx[i].Text); 
            } 
        }       
        lls.Add(str);
    }
