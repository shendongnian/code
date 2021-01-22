    private bool _pbChecked = false;
    private void pictureBox7_Click(object sender, EventArgs e)
    {
        var pictureBox = (PictureBox)sender;
        string imgPath = _pbChecked ? uncheckedImg : checkedImg;
        pictureBox.Image = Image.FromFile(imgPath);
        _pbChecked = !_pbChecked;
    }
