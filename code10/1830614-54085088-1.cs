    void loop()
    {
        int x = 0;
        int MoveRate = 1;
        while(true)
        {
            x = x + MoveRate;
            this.BeginInvoke(() => this.Location = new Point(x, 150));
            System.Threading.Thread.Sleep(10);
        } 
    }
