    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (comboBox1.Text)
        {
            case "Winter":
                this.BackgroundImage = pbWinter.Image;
                break;
            case "Spring":
                this.BackgroundImage = pbSpring.Image;
                break;
            // etc...
        }
    }
