    public ViewModel Search(string search)
    {
        ViewModel searchVM = new ViewModel();
        searchVM.Owner = searchVM.Owner.Where(o => o.Name.Contains(search));
        searchVM.Cars = searchVM.Cars.Where(c => c.Model.Contains(search));
        return searchVM;
    }
