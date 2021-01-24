    private string GetSelectedFlightID()
    {
        foreach (DataListItem item in dl1.Items)
        {
            foreach (var control in item.Controls)
            {
                if (control is HtmlInputRadioButton radioButton)
                {
                    if (radioButton.Checked)
                        return radioButton.ID;
                }
            }
        }
        return string.Empty;
    }
