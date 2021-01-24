    public ActionResult Index()
    {
        MyModel model = new MyModel()
        {
            Text = "Hello world"
        };
        return this.View(model);
    }
