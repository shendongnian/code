    private volatile bool reqToStopRec = false;
    
    void Capture()
    {
        while (!reqToStopRec)
        {
            Bitmap bm= new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(bm);
            g.CopyFromScreen(0, 0, 0, 0, bm.Size);
            pictureBox1.Image = bm;
            Thread.Sleep(300);
        }
        reqToStopRec = false;
    }
    
    private void btnRecord_Click(object sender, EventArgs e)
    {
        Thread t = new Thread(Capture);
        t.Start();
    }
    
    private void btnStop_Click(object sender, EventArgs e)
    {
        reqToStopRec = true;
    }
