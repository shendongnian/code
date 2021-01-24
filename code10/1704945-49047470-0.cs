    public PartialViewResult Test1(MainModel model)
        {
            if (ModelState.IsValid)  
            {
                return PartialView("Index", model);
            }
            return PartialView("Index");
        }
