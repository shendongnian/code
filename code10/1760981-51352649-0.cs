    public event EventHandler PicDoubleClick
    {
        add
        {
            pictureBox1.DoubleClick += value;
            label1.DoubleClick += value;
            label2.DoubleClick += value;
        }
        remove
        {
            pictureBox1.DoubleClick -= value;
            label1.DoubleClick -= value;
            label2.DoubleClick -= value;
        }
    }
