        DateTime d = Calendar1.SelectedDate;
       // int a;
        TextBox2.Text = d.ToShortDateString();
        string s = Convert.ToDateTime(TextBox2.Text).ToShortDateString();
        string s1 =  Convert.ToDateTime(Label7.Text).ToShortDateString();
        DateTime dt = Convert.ToDateTime(s).Date;
        DateTime dt1 = Convert.ToDateTime(s1).Date;
        if (dt <= dt1)
        {
            Response.Write("<script>alert(' Not a valid Date to extend warranty')</script>");
        }
        else
        {
          string diff = dt.Subtract(dt1).ToString();
           Response.Write(diff);
           Label18.Text = diff;
           Session["diff"] = Label18.Text;
          }
        
    }
   
