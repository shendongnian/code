    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        try
        {
            this.recaptcha.Validate();
            if (recaptcha.IsValid)
            {
                //valid form. post it
            }
            else
            {
                ErrorLabel.Text = "Invalid Captcha. Please re-enter the words.";
                ScriptManager.RegisterClientScriptBlock(
                    this.Page,
                    this.Page.GetType(),
                    "mykey",
                    "Recaptcha.reload();",
                    true);
                UpdatePanel2.Update();
            }
        }
        catch (Exception exception)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
        }
    }
