    Button button = new Button();
    button.ID = j.ToString() + k.ToString();
    button.OnClientClick += "return DecryptPassword(\"" + button.ID + "\", \"" + dt.Rows[j][0].ToString() + "\")";
    button.CssClass = "BtnAsLink";
    button.Text = dt.Rows[j][k].ToString();
    button.Attributes.Add("AutoPostback", "false");
