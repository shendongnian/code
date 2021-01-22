        //If you really need to find the textbox
        TextBox dateTextBox = 
                FormView1.FindControl("user_last_payment_date") as TextBox;
        if(dateTextBox == null)
        {
            //could not locate text box
            //throw exception?
        }
        DateTime date = DateTime.MinValue;
        bool parseResult = DateTime.TryParse(dateTextBox.Text, out date);
        if(parseResult)
        {
            //parse was successful, continue
        }
