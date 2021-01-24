    while (dr.Read())
    {
        string subject = dr["Subject"].ToString();
        switch (dr["ID"].ToString()) 
        {
            case "1":
                Subject1.Text += subject + " ";//$"{subject} "; //or use string builder as I've showed above 
                break;
            case "2":
                Subject2.Text += subject + " ";//$"{subject} ";
                break;
            case "3":
                Subject3.Text += subject + " ";//$"{subject} ";
                break;
            default:
                break;
        }
    }
