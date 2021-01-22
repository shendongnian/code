    // First; dont forget to assign the "Button_Click" event to your Button(s).
    private void Button_Click(object sender, EventArgs e)
    {
        // The line bellow assigns to "btn" variable the currently clicked button.
        Button btn = (Button)sender;
    
        // Then using a switch block; you can compare the button name and
        // perform the action desired for the clicked button.
        switch(btn.Name)
        {
            case "buttonName1": /* Do Something Here */ break;
            case "buttonName2": /* Do Something Here */ break;
            // etc
        }
     }
