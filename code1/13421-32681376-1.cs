    private void Main_Load(object sender, System.EventArgs e)
    {
        //Register it to Start in Load 
        //Starting from the Next time.
        this.Activated += AfterLoading;
    }
    private void AfterLoading(object sender, EventArgs e)
    {
        this.Activated -= AfterLoading;
        //Write your code here.
    }
