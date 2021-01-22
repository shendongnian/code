    DatePickerTextBox dateBox = validation.GetVisualDescendants().OfType<DatePickerTextBox>().FirstOrDefault();
    if (dateBox != null)
    {
        dateBox.Text = String.Empty;
    }
