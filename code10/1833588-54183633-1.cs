    private void Button1_Click(object sender, EventArgs e)
    {
        Random r = new Random();
        int rInt = r.Next(1, 21);
        string path = @"C:/Users/User/Desktop/Badges/Badges/";
        int i = r.Next();
        pictureBox1.Image = Image.FromFile(path + rInt.ToString() + ".png");
        // store the random number in the pictureBox
        pictureBox1.Tag = rInt;
    }
    private void Button2_Click(object sender, EventArgs e)
    {
        if (textBox1.Text == pictureBox1.Tag.ToString())
        {
            label3.Text = "You Guessed Correctly, Well Done!!";
        }
        else
        {
            label3.Text = "Incorrect Guess, Try Again!";
        }
    }
