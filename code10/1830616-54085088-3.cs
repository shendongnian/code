    void loop()
    {
        int x = 0;
        int MoveRate = 1;
        while(true)
        {
            x += MoveRate;
            this.BeginInvoke((Action)delegate () { this.Location = new Point(x, 150); });
            System.Threading.Thread.Sleep(10);
        } 
    }
