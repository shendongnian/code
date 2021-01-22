    public virtual void BlahAsync()
    {
        AsyncManager.OutstandingOperations.Increment();
        var service = new SomeWebService();
        service.GetBlahCompleted += (sender, e) =>
            {
                AsyncManager.Parameters["blahs"] = e.Result;
                AsyncManager.OutstandingOperations.Decrement();
            };
        service.GetBlahAsync();
    }
    
    public virtual ActionResult BlahCompleted(Blah[] blahs)
    {
        this.ViewData.Model = blahs;
        return this.View();
    }
