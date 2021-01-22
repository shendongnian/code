    public ActionResult Index(int id)
    {
        var model = _repository.GetModel(id);
        return Json(model);
    }
