    public void addCarItem(string carBrand, string brandType, double carsNumber, double carCost)
    {
        countAndCost.Add(carsNumber);
        countAndCost.Add(carCost);
        carType.Add(brandType, countAndCost);
        countAndCost.Clear();
        carInfo.Add(carBrand,carType);
    }
