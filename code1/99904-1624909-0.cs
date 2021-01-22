    void f(string s)
    {
      Debug.WriteLine(s + " -> Thread = " + 
        System.Threading.Thread.CurrentThread.Name);
    }
    
    private void button_Click(object sender, EventArgs e)
    {
      Debug.WriteLine("Start button_Click");
      f("straight call in button_Click");
      BeginInvoke(new Action<string>(f), "async call through BeginInvoke()");
      Debug.WriteLine("End button_Click");
    }
