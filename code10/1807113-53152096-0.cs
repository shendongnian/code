    int i = 0;
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        //check if the viewstate with the value exists
        if (ViewState["timerValue"] != null)
        {
            //cast the viewstate back to an int
            i = (int)ViewState["timerValue"];
        }
        i++;
        Label3.Text = i.ToString();
        //store the value in the viewstate
        ViewState["timerValue"] = i;
    }
