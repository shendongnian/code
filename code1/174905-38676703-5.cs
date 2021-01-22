    progress = new Progress<int>(value =>
    {
        toolStripProgressBar1.Visible = true;
        if (value >= 100)
        {
            toolStripProgressBar1.Visible = false;
            toolStripProgressBar1.Value = 0;
        }
        else if (value > 0)
        {
            toolStripProgressBar1.Value = value;
        }
     });
