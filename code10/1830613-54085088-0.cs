    void loop()
    {
        this.BeginInvoke((Action)delegate () {
            int x = 0;
            int y = 0;
            int MoveRate = 1;
            Point TopLeft = this.Location;
            Point TopRight = new Point (this.Location.X + this.Width, this.Location.Y);
            while (true)
            {
                x += MoveRate;
                this.Location = new Point(x, 150);
                System.Threading.Thread.Sleep(10);
            }
        });     
    }
