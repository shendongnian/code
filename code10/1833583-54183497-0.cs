    private int selectedImage;
    private void Button1_Click(object sender, EventArgs e)
    {
        Random r = new Random();
        selectedImage = r.Next(1, 21);
        string path = @"C:/Users/User/Desktop/Badges/Badges/";
         int i = r.Next();
        pictureBox1.Image = Image.FromFile(path + selectedImage.ToString() + ".png");
    }
    private void Button2_Click(object sender, EventArgs e)
    {
        string path = @"C:/Users/User/Desktop/Badges/Badges/";
        if (textBox1.Text == selectedImage.ToString())
        {
            label3.Text = "You Guessed Correctly, Well Done!!";
        }
        else
        {
            label3.Text = "Incorrect Guess, Try Again!";
        }
    }
