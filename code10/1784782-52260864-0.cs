    public ObservableCollection<City> Cities = new ObservableCollection<City>();
    public async void CargarCiudades()
    {
       var list = await App.Repository.City.GetAsync();
       foreach (var i in list)
       {
            this.Cities.Add(i);
       }
    }
    
