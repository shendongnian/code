    private void button1_Click(object sender, EventArgs e)
    {
        var guesser = new BrutePasswordGuesser();
        var guess = new String(guesser.CurrentGuess);
        while (textBox1.Text != guess)
        {
            textBox2.Text = guess;
            if (!guesser.NextGuess())
            {
                label1.Text = "Maximum guess size reached.";
                break;
            }
            guess = new String(guesser.CurrentGuess);
        }
        if (textBox1.Text == textBox2.Text)
        {
            Label1.Text = "Password Correct";
        }
    }
