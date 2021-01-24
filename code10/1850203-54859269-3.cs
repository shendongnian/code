    var regex = new Regex("[0-9]");
    if (regex.IsMatch(textBox1.Text)) {
        MessageBox.Show("There was a number inside name textbox.","Error in name field!");
        return;
    }
    try {
        Convert.ToInt32(textBox2.Text);
    } catch (Exception) {
        MessageBox.Show("The input in age field was not valid","Error in name field!");
        return;
    }
