    public IHttpActionResult Request(int[] ids)
    {
        foreach(var id in ids)
        {
           BackgroundJob.Enqueue<IMyService>(x => x.DoWork(id));
        }
    }
    [Queue("default")]// add this attribute on your function
    public void DoWork() { 
	    //Magical IO code here
    }
