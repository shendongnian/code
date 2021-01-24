    void PlayTime(object sender, EventArgs e)
    {
        
        // pictureBox1.Image = Image.FromFile(imges[counter++]);
        pictureBox1.ImageLocation = imges[counter++]; // better to use it this way.
        if (counter >= imges.Length) counter = 0; // Handling out of Bounds
    }
