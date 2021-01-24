    public async Task<ActionResult> Foo() 
    {
        var dataATask = _dataARepository.GetDataAsync();
        var dataBTask = Task.Run(_dataBRepository.GetData());
        await Task.WhenAll(dataATask, dataBTask);
        var viewModel = new ViewModel(dataATask.Result, dataBTask.Result);
        return View(viewModel);
    }
