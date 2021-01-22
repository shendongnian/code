    public MyPanel()
    {
        for (int i = 0; i < 20; i++)
        {
            PictureBox p = new PictureBox();
            p.Click += MyHandler;
            Controls.Add(p);
        }
    }
