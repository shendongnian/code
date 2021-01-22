    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Validate();
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
            Result.Text = "Thanks for sending your data";
        else
            Result.Text = "There are some errors, please correct them and re-send the form.";
    }
    protected void ValidateEmpID2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            args.IsValid = (int.Parse(args.Value) % 5 == 0);
        }
        catch
        {
            args.IsValid = false;
        }
    }
    protected void OptionsChanged(object sender, EventArgs e)
    {
        // Examine all the validators on the back.
        foreach (BaseValidator validator in Page.Validators)
        {
            // Turn the validators on or off, depending on the value
            // of the "Validators enabled" check box (chkEnableValidators).
            validator.Enabled = chkEnableValidators.Checked;
            // Turn client-side validation on or off, depending on the value
            // of the "Client-side validation enabled" check box
            // (chkEnableClientSide).
            validator.EnableClientScript = chkEnableClientSide.Checked;
        }
        // Configure the validation summary based on the final two check boxes.
        Summary.ShowMessageBox = chkShowMsgBox.Checked;
        Summary.ShowSummary = chkShowSummary.Checked;
    }
   
