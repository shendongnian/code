    private void classAinput_TextChanged(object sender, EventArgs e)
    {
        if (!(classAinput.Text == "" || int.TryParse(classAinput.Text, out int _))) {
            invalidFormatError();
        }
    }
