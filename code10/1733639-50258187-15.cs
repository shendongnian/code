    List<ViewModelOfPage> vm = new ViewModelOfPage;
    foreach (var row in resultsObj)
    {
        //An example of only selecting certain results
        if(row.Name == "John" && row.TotalPrice > 15){
            var tempVm = new ViewModelOfPage
            {
                Name = row.Name,
                ImageUrl = row.ImageUrl ,
                ResortDetails = row.ResortDetails,
                CheckIn = row.CheckIn,
                Address = row.Address,
                TotalPrice row.TotalPrice
            };
            vm.add(tempVm);
        }
    }
    view("ourview",vm);
