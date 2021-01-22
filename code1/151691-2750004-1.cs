    public ActionResult Create()
    {
        var viewModel = new CreateViewModel(); // Strongly Typed View
        using(Entities dataModel = new Entities()) // 'te' I assume is your data model
        {
             viewModel.Methods = dataModel.Methods.Select(x => new SelectListItem()
             {
                  Text = x.Description,
                  Value = x.method_id.ToString()
             });
        }
        return View(viewModel);
    }
