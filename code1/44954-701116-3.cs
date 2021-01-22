    protected void TextBoxDTownCity_Validate(
        object source, ServerValidateEventArgs args)
    {
        string v = TextBoxDTownCity.Text;
        if (v == string.Empty)
        {
            args.IsValid = false;  // field is empty
        }
        else
        {
            // do your other validation tests here...
        }
    }
