    DateTime dob = DateTime.Parse("03/10/1982");  
    string message = ValidateDate(dob);
    lbldatemessage.Visible = !StringIsNullOrWhitespace(message);
    lbldatemessage.Text = message ?? ""; //Ternary if message is null then default to empty string
        
