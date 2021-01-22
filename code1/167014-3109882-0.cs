    private void LogLastButton(Button button)
    {
       Session["LastButtonId"] = button.ID;
    }
    protected void ButtonView_Click(object sender, EventArgs e)
    {
       this.LogLastButton((Button)sender);
    }
    protected void ButtonViewDayWise_Click(object sender, EventArgs e)
    {
       this.LogLastButton((Button)sender);
    }
