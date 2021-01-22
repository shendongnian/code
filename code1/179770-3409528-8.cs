    private void Form1_Load(object sender, EventArgs e)
    {
        Observable.Context = SynchronizationContext.Current;
        var textchanged = Observable.FromEvent<EventArgs>(textBox1, "TextChanged");
    
        //You can change 300 to something lower to make it more responsive
        textchanged.Throttle(300).Subscribe(filter);
    }
    
    private void filter(IEvent<EventArgs> e)
    {
        var searchStrings = textBox1.Text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
    
        //my randStrings is your unfiltered messages
    
        StringComparison comp = StringComparison.CurrentCulture; //Do what you want here
    
        var resultList = from line in randStrings
                         where searchStrings.All(item => line.IndexOf(item, comp) >= 0)
                         select line;
        //A lot faster but only gives you first 100 finds then uncomment:
        //resultList = resultList.Take(100);
    
        listBox1.BeginUpdate();
        listBox1.Items.Clear();
        listBox1.Items.AddRange(resultList.ToArray());
        listBox1.EndUpdate();
    }
