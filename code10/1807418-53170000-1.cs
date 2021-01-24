    List<MyViewModel> combinedTablesList = new List<MyViewModel>();
    MyViewModel myViewModel = new MyViewModel();
    int id = 1;
    //select all your HR values as a list from your database repository.
    List<HR> table1 = yourRepository.HR().toList();
    foreach(var item in table1)
    {
        myViewModel.Id = id;
        myViewModel.FirstName = item.FirstName;
        myViewModel.LastName = item.LastName ;
        myViewModel.PhoneNumber= item.PhoneNumber;
        combinedTablesList.add(myViewModel);
        id++;
    }
