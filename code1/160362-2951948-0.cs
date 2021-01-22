    public MyPanel()
    {
        for (int i = 0; i < 20; i++)
        {
            PictureBox p = new PictureBox();
            var pictureBoxIndex = i;
            p.Click += (s,e) =>
            {
                //Your code here can reference pictureBoxIndex if needed.
            };
            Controls.Add(p);
        }
    }
