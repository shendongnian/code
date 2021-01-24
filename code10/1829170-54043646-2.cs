    var awaiter2 = t1.WaitableDebouncer(h => t1.TextChanged += h, h => t1.TextChanged -= h, 
        scheduler, 
        canceller.Token, 
        TimeSpan.FromMilliseconds(5000), 
        async () =>
        {
            savedValue = t1.Text;
            Invoke(new Action(() => l1.Text = savedValue));
        });
    tasks.Add(awaiter2);  
