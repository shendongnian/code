    private MyObject abc()
    {
        //your going to have to create a MyObject class
        return new MyObject(){ success = false, responseText = "Input-Values not valid" };
    }
    
    public ActionResult ABC()
    {
        return Json(this.abc());
    }
