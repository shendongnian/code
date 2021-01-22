    public MyPanel()
    {
        for (int i = 0; i < 20; i++)
        {
            Controls.Add(new PictureBox());
        }
        RegisterFunction(MyHandler);
    }
