    public ViewResult AddQueryBox(ViewModel viewModel) 
    {
        //Add blank sql query to list
        viewModel.listOfSqlQueries.Add(new SqlQuery());
        //return calling view with newly updated viewmodel
        return View("View", viewModel);
    }
