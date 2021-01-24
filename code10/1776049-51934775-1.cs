    private void btnSubmit_Click(object sender, EventArgs e)
    {
        // Validate that rent textbox contains a number
        int rentDuration;
        if (!int.TryParse(txtRentDuration.Text, out rentDuration))
        {
            MessageBox.Show("Please enter a valid number for rent duration");
            return;
        }
        // Determine vehicle price based on which option was selected
        int vehiclePrice;
        if (optToyotaCorolla.Checked) vehiclePrice = 50000;
        else if (optRollsRoyce.Checked) vehiclePrice = 250000;
        else if (optSuzikiWagonR.Checked) vehiclePrice = 2500;
        else if (optToyotaCorolla.Checked) vehiclePrice = 10000;
        else
        {
            MessageBox.Show("Please select a vehicle");
            return;
        }
        // Determine driver price
        int driverPrice;
        if (optWithDriver.Checked) driverPrice = 1500;
        else if (optWithoutDriver.Checked) driverPrice = 0;
        else
        {
            MessageBox.Show("Please select a driver");
            return;
        }
        // Finally set the text to the return value of our original method,
        // passing in the appropriate values based on the user's selections
        txtTotalValue.Text = GetTotalValue(vehiclePrice, driverPrice, rentDuration).ToString();
    }
