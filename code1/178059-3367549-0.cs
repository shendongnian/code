    ICollection temp;
            if (includeAllCheck.Checked)
            {
    
                temp = currentMessages;            
            }
            else
            {
                temp = currentLeads;
                 
            }
    if (SelectedLead == (temp.Count - 1))
                    SelectedLead = 0;
                else
                    SelectedLead += 1;
