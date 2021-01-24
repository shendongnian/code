    protected void Image_Click(object sender, EventArgs e)
    {
        //create a variable for the clicks
        int ButtonClicks = 0;
        //check if the viewstate exists
        if (ViewState["ButtonClicks"] != null)
        {
            //cast the viewstate back to an int
            ButtonClicks = (int)ViewState["ButtonClicks"];
        }
        //increment the clicks
        ButtonClicks++;
        //update the viewstate
        ViewState["ButtonClicks"] = ButtonClicks;
        //show results
        Label1.Text = "Button is clicked " + ButtonClicks + " times.";
    }
