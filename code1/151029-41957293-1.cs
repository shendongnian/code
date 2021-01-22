    while (dr.Read())
    {                    
        string checkValue = dr.GetValue(0).ToString();
        if (checkValue == myEmpIdTextbox.Text)
        {
            Texbox2.Text = dr.GetValue(1).ToString();
            Texbox3.Text = dr.GetValue(2).ToString();
        }
    }
