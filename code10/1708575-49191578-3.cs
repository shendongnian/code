        var picBox = new PictureBox()
        {
            Image = Properties.Resources.ProgressStage_LT_GRAY,
            SizeMode = PictureBoxSizeMode.Zoom,
            Dock = DockStyle.Fill,
            Tag = new PaintModel { Text = text, Locaiton = new Point(textx, texty) }
        };
