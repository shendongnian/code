    ConcurrentBag<string> result = new ConcurrentBag<string>();
    List<string> result2 = new List<string>();
    public async Task Scan(string path)
    {
        await Task.Run(async () =>
        {
            var subs = Directory.GetDirectories(path);
            await Task.WhenAll(subs.Select(s => Scan(s)));
            result.Add(Enumerable.Range(0, 1000000).Sum(i => path[i % path.Length]).ToString());
        });
    }
    public void Scan2(string path)
    {
        result2.Add(Enumerable.Range(0, 1000000).Sum(i => path[i % path.Length]).ToString());
        var subs = Directory.GetDirectories(path);
        foreach (var s in subs) Scan2(s);
    }
    private async void button4_Click(object sender, EventArgs e)
    {
        string dir = @"d:\tmp";
        System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();
        st.Start();
        await Scan(dir);
        st.Stop();
        MessageBox.Show(st.ElapsedMilliseconds.ToString());
        st = new System.Diagnostics.Stopwatch();
        st.Start();
        Scan2(dir);            
        st.Stop();
        MessageBox.Show(st.ElapsedMilliseconds.ToString());
        
        MessageBox.Show(result.OrderBy(x => x).SequenceEqual(result2.OrderBy(x => x)) ? "OK" : "ERROR");
    }
