    public ActionResult Show(int id)
    {
        MyObject myObject = repository.GetMyObjectById(id)
        MyObjectViewModel movm = myObject; 
        movm.Enabled = myObject.number > 0;
        return View(movm);
    }
