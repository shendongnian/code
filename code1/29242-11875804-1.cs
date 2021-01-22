    // Boolean flag used to determine when a character other than a number is entered.
    private bool nonNumberEntered = false;
    // Handle the KeyDown event to determine the type of character entered into the     control.
    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
    // Initialize the flag to false.
    nonNumberEntered = false;
    // Determine whether the keystroke is a number from the top of the keyboard.
    if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
    {
        // Determine whether the keystroke is a number from the keypad.
        if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
        {
            // Determine whether the keystroke is a backspace.
            if (e.KeyCode != Keys.Back)
            {
                // A non-numerical keystroke was pressed.
                // Set the flag to true and evaluate in KeyPress event.
                nonNumberEntered = true;
            }
        }
    }
}
    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (nonNumberEntered == true)
        {
           MessageBox.Show("Please enter number only..."); 
           e.Handled = true;
        }
    }
