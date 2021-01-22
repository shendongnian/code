    private void Unreactive(string msg)
    {
        var message = msg.ToCharArray();
        for(int i = 0; i < message.Length; i++)
        {
            var l = new Label()
            { 
                Text = message[i].ToString(), 
                AutoSize = true, 
                TextAlign = ContentAlignment.MiddleCenter 
            };
            Controls.Add(l);
            int closure = i;
            this.MouseMove += (s, e) => LabelDelayMove(closure, e, l);
        }
    }
    private void LabelDelayMove(int i, MouseEventArgs e, Label l)
    {
        Point p = new Point(e.X + i * 12 - 5, e.Y - 15);
        var timer = new System.Threading.Timer((_) => LabelMove(l, p), null, i * 70, System.Threading.Timeout.Infinite);
    }
    private void LabelMove(Label l, Point location)
    {
        this.BeginInvoke(new Action(() => l.Location = location));
    }
