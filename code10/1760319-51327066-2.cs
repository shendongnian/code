    String AllRows = txtConfirm.Text; // add TextBox data in this String variable
    // Iterate to all rows of your gridview
    foreach (GridViewRow row in GridView1.Rows)
       AllRows += "Course: " + GridView1.SelectedRow.Cells[0].Text; + "\n";
    txtConfirm.Text = AllRows; // set String variable to the TextBox
