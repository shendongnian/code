      void CustomersGridView_SelectedIndexChanged(Object sender, EventArgs e)
      {
        // Get the currently selected row using the SelectedRow property.
        GridViewRow row = CustomersGridView.SelectedRow;
    
        // Display the company name from the selected row.
        // In this example, the third column (index 2) contains
        // the company name.
        MessageLabel.Text = "You selected " + row.Cells[2].Text + ".";
      }
