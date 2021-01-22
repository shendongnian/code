    private delegate void DoStuff(); //delegate for the action
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //create the delegate
        DoStuff myAction = new DoStuff(SomeVeryLongAction); 
        //invoke it asynchrnously, control passes to next statement
        myAction.BeginInvoke(null, null);
        Button1.Text = DateTime.Now.ToString();
    }
    private void SomeVeryLongAction()
    {
        for (int i = 0; i < 100; i++)
        {
            //simulation of some VERY long job
            System.Threading.Thread.Sleep(100);
        }
    }
