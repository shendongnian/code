    private void button1_Click(object sender, EventArgs e) {
        //Hardcoded number.
        int SecNum = 75;
    
        //Users input.
        int Guess = Convert.ToInt32(textBox1.Text);
    
        if (Guess < SecNum) {
            this.BackColor = Color.Blue;
            OutputText.Text = "Too low.";
        } else if (Guess > SecNum) {
            this.BackColor = Color.Red;
            OutputText.Text = "Too high.";
        } else {
            this.BackColor = Color.Green;
            OutputText.Text = "That's correct!";
        }
    }
