    ViewBag.Cars = ListofCars();
    private IEnumerable<string> ListofCars()
    {
        CarRepo = new CarRepo();
        IEnumerable<CarModel> CCars;
        using (car)
        {
            CCars = cars.SelectAll() as IList<CarModel>;
        }
        var Cars = Cars.Select(b => b.Car).Distinct().OrderBy(x => x);
        return cities;
    }
