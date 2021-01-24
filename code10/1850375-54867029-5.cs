     public ActionResult Show(int pageNumber)
    {
      var viewModel = new myViewModel();
    viewmodel.PageNumber = pageNumber; // pass it to view again you may need to give the selected page special css
    }
