string email=textbox1.text;
System.Text.RegularExpressions.Regex expr= new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
    `if (expr.IsMatch(email))
                MessageBox.Show("valid");
               
            else MessageBox.Show("invalid");`
