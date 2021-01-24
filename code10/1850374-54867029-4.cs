         public ActionResult Show()
        {
        var viewModel = new myViewModel{
        myProduct= DB.Products..ToList(),
    
        myImages= DB.Images.OrderBy(a => a.Id).Skip(pageSize * (pageNumber- 1))
             .Take(pageSize).ToList(); // this will fetch only required data from database
    }
        return View(viewModel);
        }
