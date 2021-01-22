    object c1 = new Class1();
    int trials = 10000000;
    Class1 tester;
    Stopwatch watch = Stopwatch.StartNew();
    for (int i = 0; i < trials; i++)
    {
        if (c1 is Class1)
        {
            tester = (Class1)c1;
        }
    }
    watch.Stop(); 
    MessageBox.Show(watch.ElapsedMilliseconds.ToString()); // ~104 ms 
    watch.Reset();
    watch.Start();
    for (int i = 0; i < trials; i++)
    {
        tester = c1 as Class1;
        if (tester != null)
        {
            // 
        }
    }
    watch.Stop(); 
    MessageBox.Show(watch.ElapsedMilliseconds.ToString()); // ~86 ms
    watch.Reset();
    watch.Start();
    for (int i = 0; i < trials; i++)
    {
        if (c1 is Class1)
        {
            // 
        }
    }
    watch.Stop();     
    MessageBox.Show(watch.ElapsedMilliseconds.ToString()); // ~74 ms
    watch.Reset();
    watch.Start();
    for (int i = 0; i < trials; i++)
    {
        //
    }
    watch.Stop();     
    MessageBox.Show(watch.ElapsedMilliseconds.ToString()); // ~50 ms
