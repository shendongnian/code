    [Transaction]
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult EditDataDefinition(int id, FormCollection form)
    {
        T itemToUpdate = repository.Get(id);
        UpdateModel(itemToUpdate, form.ToValueProvider());
        if (itemToUpdate.IsValid())
        {
            repository.SaveOrUpdate(itemToUpdate);
            return Json(ValidationResultToJson(itemToUpdate.ValidationResults()));
        }
        repository.DbContext.RollbackTransaction();
        return Json(ValidationResultToJson(itemToUpdate.ValidationResults()));
    }
