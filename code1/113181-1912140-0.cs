    Car [] cars = //...
        List<Car> filteredList = new List<Car>();
        for(int i = 0; i < cars.Length; i++)
        {
            if(cars[i].IsAvailable)
               filteredList.Add(cars[i]);
        }
        Car[] filtered = filteredList.ToArray();
