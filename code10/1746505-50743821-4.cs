    private void SomeCustomEvent(Object sender, EventArgs e) {
        RadioButton rb = (RadioButton)sender;
        if (rb.Checked) { // From either radio button
            M_TitleTextBox.Text = "A radio button was clicked.";
            if(rb.Name = "radBtnOne") // To check which one was checked.
            {
                // Now we know which radio button was clicked. Same process for the second
            }
        }
    }
