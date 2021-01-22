    protected void CustomValidator1_ServerValidate(object sender, ServerValidateEventArgs e)
    {
        DateTime d;
        e.IsValid = DateTime.TryParseExact(e.Value, "dd/MM/yyyy", CultureInfo.InvarinatCulture, DateTimeStyles.None, out d);
    }
