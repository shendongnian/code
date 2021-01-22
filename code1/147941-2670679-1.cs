    private void btnSaveDetails_Click(object sender, EventArgs e)
    {
        Delivery d = new Delivery(
            txtNameBox.Text, txtAddressBox.Text, txtDayBox.Text,  
            txtTimeBox.Text, txtMealBox.Text, txtInstructionsBox.Text, 
            txtStatusBox.Text
        );
        mainForm.myDeliveries.Add(d);
        this.DialogResult = DialogResults.OK;
    }
