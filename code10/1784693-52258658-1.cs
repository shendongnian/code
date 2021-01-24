    private void btnExport_Click(object sender, EventArgs e)
    {
        month = monthsDictionary[cbMonth.SelectedText];
        //This will give you the value of the key.
        //Ex. If march is chosen then 3 is what is given back as an int.
        int year = Int32.Parse(mtbYear.Text);
        MessageBox.Show(month.ToString() + "   " + year.ToString()); // to check values
    }
