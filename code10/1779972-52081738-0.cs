    foreach(var item in viewModel.Values) //loop all array data
    {
        var model = new EmbellishmentProductDetailRecord();
          model.EmbellishmentProductTypeID = viewModel.Id;
          model.EmbellishmentPositionID = item;
          model.EmbellishmentID = ??? //I dont know which value to bind
          _epdRepository.Insert(model);
    }
   
