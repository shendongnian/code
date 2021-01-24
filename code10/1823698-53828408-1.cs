    public async Task<ActionResult> Foo() 
    {
        var dataATask = _dataARepository.GetDataAsync();
        var dataBResult = _dataBRepository.GetData();
        await dataATask;
        var viewModel = new ViewModel(dataATask.Result, dataBResult);
        return View(viewModel);
    }
