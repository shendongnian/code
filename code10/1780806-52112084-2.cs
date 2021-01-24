    while (dr.Read())
    {
        string subject = dr.Field<string>("Subject");
        switch (dr.Field<int>("ID")) //int or whatever your ID type is
        {
            case 1:
                Subject1.Text += $"{subject} "; //or use string builder as I've showed above 
                break;
            case 2:
                Subject2.Text += $"{subject} ";
                break;
            case 3:
                Subject3.Text += $"{subject} ";
                break;
            default:
                break;
        }
    }
