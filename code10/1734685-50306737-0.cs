    private void Form1_Load(object sender, EventArgs e)
    {
        IObservable<long> query =
            Observable
                .FromEventPattern<EventHandler, EventArgs>(
                    h => TXBheight.TextChanged += h,
                    h => TXBheight.TextChanged -= h)
                .Select(x => Observable.Timer(TimeSpan.FromMilliseconds(250.0)))
                .Switch()
                .ObserveOn(this);
        IDisposable subscription = query.Subscribe(ep =>
        {
            if (int.Parse(TXBheight.Text) < 8)
            {
                TXBheight.Text = "8";
            }
            else if (int.Parse(TXBheight.Text) > 32)
            {
                TXBheight.Text = "32";
            }
        });
    }
