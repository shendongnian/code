    // client-side
    function TextBoxDCountyClient(sender, args)
    {
        var v = document.getElementById('<%=TextBoxDTownCity.ClientID%>').value;
        if (v == '')
        {
            args.IsValid = false;  // field is empty
        }
        else
        {
            // do your other validation tests here...
        }
    }
    // server-side
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
