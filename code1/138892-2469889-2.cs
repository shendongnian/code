    void Form1_Load(object sender, EventArgs e)
    {
       Reactive("Time flies like an arrow");
    }
    private void Reactive(string msg)
    {
        var mousemove = Observable.FromEvent<MouseEventArgs>(this, "MouseMove");
        var message = msg.ToCharArray();
        for(int i = 0; i < message.Length; i++)
        {
            var l = new Label()
            { 
                Text = message[i].ToString(), 
                AutoSize = true, 
                TextAlign = ContentAlignment.MiddleCenter 
            };
            int closure = i;
            mousemove
                .Delay(TimeSpan.FromSeconds(0.07 * i), Scheduler.Dispatcher)
                .Subscribe(e =>
                {
                    l.Left = e.EventArgs.X + closure * 12 - 5;
                    l.Top = e.EventArgs.Y + 15;
                });
            Controls.Add(l);
        }
    }
