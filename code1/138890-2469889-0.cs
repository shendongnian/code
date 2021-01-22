    void Form1_Load(object sender, EventArgs e)
    {
        var mousemove = Observable.FromEvent<MouseEventArgs>(this, "MouseMove");
        var message = "Time flies like an arrow".ToCharArray();
        for (int i = 0; i < message.Length; i++)
        {
            var l = new Label() 
            { 
                Text = message[i].ToString(), 
                AutoSize = true, 
                TextAlign = ContentAlignment.MiddleCenter 
            };
            int closure = i;
            mousemove
                .Delay(TimeSpan.FromSeconds(0.1 * i))
                .ObserveOnDispatcher()
                .SubscribeOnDispatcher()
                .Subscribe(evnt =>
                {
                    l.Left = evnt.EventArgs.X + closure * 15 + 10;
                    l.Top = evnt.EventArgs.Y;
                });
            Controls.Add(l);
        }            
    } 
