    public void addCarItem(string carBrand, string brandType, double carsNumber, double carCost)
    {
        Dictionary<string, List<double>> carType = new Dictionary<string, List<double>>();        countAndCost.Add(carsNumber);
        countAndCost.Add(carCost);
        carType.Add(brandType, countAndCost);
        // You can't "re-use" this variable:
        // countAndCost.Clear();
        carInfo.Add(carBrand,carType);
    }
