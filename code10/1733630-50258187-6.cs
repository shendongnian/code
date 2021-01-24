        List<ViewModelOfPage> vm = new ViewModelOfPage;
        foreach (var row in resultsObj)
        {
        var tempVm = new ViewModelOfPage
        {
            name = row.Name,
            ImageUrl = row.ImageUrl ,
            ResortDetails = row.ResortDetails,
            CheckIn = row.CheckIn,
            Address = row.Address,
            TotalPrice row.TotalPrice
        };
        vm.add(tempVm);
        }
    return view("ourview",vm);
