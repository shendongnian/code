    Load += delegate
    {
        if (formContext == "add")
        {
            Text = "Add member";
        }
        if (formContext == "edit")
        {
            Text = "Change role";
            userTextBox.Enabled = false;
            searchkButton.Visible = false;
        }
    };
