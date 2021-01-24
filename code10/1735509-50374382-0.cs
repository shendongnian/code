    void CalculateAverage()
    {
        AvgPricePerRoom =
              _selectedStreet.HouseList[0].Price / _selectedStreet.HouseList[0].Rooms / 3 +
              _selectedStreet.HouseList[1].Price / _selectedStreet.HouseList[1].Rooms / 3 +
              _selectedStreet.HouseList[2].Price / _selectedStreet.HouseList[2].Rooms / 3;
    }
