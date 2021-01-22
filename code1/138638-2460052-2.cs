    AutoResetEvent pro = new AutoResetEvent(false);
    AutoResetEvent con = new AutoResetEvent(true);
    public void produser()
    {
        while(true)
        {
            con.WaitOne();
            pro.Set();
        }
    }
    public void consumer()
    {
        while (true)
        {
        pro.WaitOne();
           .................****
        con.Set();
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        Thread th1 = new Thread(produser);
        th1.Start();
        Thread th2 = new Thread(consumer);
        th2.Start();
    }
