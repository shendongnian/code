    string StrMode;
    if (!string.IsNullOrEmpty(StrMode))
    {  
        switch (StrMode.Trim())
        {
            case "Souse":
            {
                 //Statement Eg:  
                 MesssageBox.Show("Souse");
                 break;
            }
            case "Company Agent":
            {
                 //Statement Eg:
                 MesssageBox.Show("Souse");
                 break; 
            }
               
            default:
                 return;
        }
    }
