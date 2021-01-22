    public ActionResult MyAction()
    {
        var myObject = new MyData 
        {
            Prop1 = new MyDataInfo(),
            Prop2 = new MyDataInfo()
        };
        return View(myObject);
    }
