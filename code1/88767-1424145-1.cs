    int lastYear = 0;
    protected void litYourYearControl_DataBinding(object sender, System.EventArgs e)
    {
        Literal lit = (Literal)(sender);
        string displayText = "";
        int year = (int)(Eval("YourYearField"));
        if (year != lastYear)
        {
            displayText = year.ToString();
            lastYear = year;
        }
        lit.Text = displayText;
    }
