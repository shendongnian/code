    string email = Request.QueryString["email"];
    string email1 = "";
    for(int i = 0; i < email.Length; i++)
    {
        if (email[i] != ',')
        {
            email1 += email[i].ToString();
        }
        else
        {
            break;
        }
    }
    email = email1;
