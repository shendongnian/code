    public ActionResult Index() {
        MyEntity entity = fetchEntity();
    
        MyModel model = new MyModel {
            SomeData = entity.Data,
            FileId = entity.SomeFile.ID
        };
        return View(model);
    }
