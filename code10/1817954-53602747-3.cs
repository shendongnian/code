    Dictionary<string, Image> Images = new Dictionary<string, Image>();
    Images.Add("apple", Properties.Resources.apple);
    Image apple = Properties.Resources.apple;
    private void apple1_Click(object sender, EventArgs e)
    {
        apple1.Image = Images["apple"];
    
        if (apple1.Image==apple2.Image)
        {
            apple1.Visible = false;
            apple2.Visible = false;
        }
    }
    private void apple2_Click(object sender, EventArgs e)
    {
        apple2.Image = Images["apple"];
    }
