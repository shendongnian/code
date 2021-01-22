    foreach (GridViewRow row in MyGridView.Rows) {
        Button deleteButton = (Button)row.Cells(0).Controls(0);
        if (statusOnThisRowIsActive) {
            deleteButton.Text = "Active";
        } else {
            deleteButton.Text = "Restore";
        }
    }
