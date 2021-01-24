    var awaiter1 = b1.WaitableDebouncer(h => b1.Click += h, h => b1.Click -= h, 
        scheduler, 
        canceller.Token, 
        TimeSpan.FromMilliseconds(5000), 
        async () =>
        {
            Invoke(new Action(() =>
            {
                if (p1.BackColor == Color.Red)
                {
                    p1.BackColor = Color.Orange;
                }
                else if (p1.BackColor == Color.Orange)
                {
                    p1.BackColor = Color.Yellow;
                }
                else if (p1.BackColor == Color.Yellow)
                {
                    p1.BackColor = Color.HotPink;
                }
                else
                {
                    p1.BackColor = Color.Red;
                }
            }));
        });
    tasks.Add(awaiter1);
