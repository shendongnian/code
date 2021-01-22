    public ActionResult Create()
    {
        List<FormMetadata> formItems = GetFormItems();
        return View(formItems);
    }
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Create(List<FormMetadata> formItems)
    {
        if(ModelState.isValid)
        {
            MyUpdate()
            save()
        }
        else
        {
            return view(formItems)
        }
    }
