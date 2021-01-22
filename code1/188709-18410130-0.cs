     void IterateThroughControls(Control parent)
        {
            foreach (Control SelectedButton in parent.Controls)
            {
                if (SelectedButton is Button)
                {
                    ((Button)SelectedButton).Attributes.Add("onclick", " this.disabled = true; " + Page.ClientScript.GetPostBackEventReference(((Button)SelectedButton), null) + ";");
                }
    
                if (SelectedButton.Controls.Count > 0)
                {
                    IterateThroughControls(SelectedButton);
                }
            }
        }
