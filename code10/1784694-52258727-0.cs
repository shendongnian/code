    private void btnExport_Click(object sender, EventArgs e)
        {
            int month = 0; //just a default value
            var monthNumber = DateTime.ParseExact((string)cbMonth.SelectedValue, "MMMM", CultureInfo.InvariantCulture).Month;
    
            int year = Int32.Parse(mtbYear.Text);
            MessageBox.Show(monthNumber.ToString() + "   " + year.ToString()); // to check values
    
        }
