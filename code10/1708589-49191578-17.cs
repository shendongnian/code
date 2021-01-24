    private void AddPictureWithText(string text, int textX, int textY, int col, int row)
    {
        var picBox = new PictureBox
        {
            Image = Properties.Resources.ProgressStage_LT_GRAY,
            SizeMode = PictureBoxSizeMode.Zoom,
            Dock = DockStyle.Fill,
            Tag = PaintPictureBox
        };
        picBox.Paint += PaintPictureBox;
        tableLayoutPanel1.Controls.Add(picBox, col, row);
        void PaintPictureBox(object sender, PaintEventArgs e)
            => picPaint(sender, e, text, textX, textY);
    } 
