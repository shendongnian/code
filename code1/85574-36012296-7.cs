    List<string> Recipients = GetRecipients();
    
    bool IsValidEmailAddresses = IsValidEmailAddresses(Recipients);
                
    if (IsValidEmailAddresses)
    {
        //Emails are valid. Your code here
    
    }
    else
    {
        StringBuilder sb = new StringBuilder();
    
        sb.Append("The following addresses are invalid:");
    
        List<string> InvalidEmails = GetInvalidEmailAddresses(Recipients);
    
        foreach (string InvalidEmail in InvalidEmails)
        {
            sb.Append("\n" + InvalidEmail);
    
        }
    
        MessageBox.Show(sb.ToString());
    
    }
