    private void txtEntryDate_Validated(object sender, EventArgs e)
       {
         if (!string.IsNullOrEmpty(txtEntryDate.Text))
           {
             DateTime entryDate;
            if (DateTime.TryParseExact(txtEntryDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out entryDate))
           {
             // further actions for validations
           }
           else
           {
           setTooltip(txtEntryDate, "txtEntryDate", "Invalid date format date must be formatted to dd/MM/yyyy");
                    txtEntryDate.Focus();
            }
            }
            else
            {
            setTooltip(txtEntryDate, "txtEntryDate", "Please provide entry date in the format of dd/MM/yyyy");
            txtEntryDate.Focus();
            }
           }
