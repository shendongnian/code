    public static IQueryable<Car> WhereKey(this IQueryable<Car> cars, int id, string key)
    {
        return cars.Where(car => car.Id == id
                && key == car.Process.Name.ToString() + "_" + car.LocalSequenceNumber.ToString());
    }
