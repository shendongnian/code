    private void copyToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Image myData = this.ActiveControl.BackgroundImage;
        Clipboard.SetImage(myData);
    }
    private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Image myData = Clipboard.GetImage();
        this.ActiveControl.BackgroundImage = myData;
    }
