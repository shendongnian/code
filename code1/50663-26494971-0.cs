    ModelState.Clear();
    //This will clear the address that was submited
    viewModel.Address = new Address();
    viewModel.Message = "Dados salvos com sucesso!";
    return View("Addresses", ReturnViewModel(viewModel));
