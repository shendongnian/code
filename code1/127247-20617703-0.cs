        private void textBox_Enter(object sender, EventArgs e)
        {
            ActiveForm.AcceptButton = Button1; // Button1 will be 'clicked' when user presses return
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            ActiveForm.AcceptButton = null; // remove "return" button behavior
        }
