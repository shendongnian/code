    Coupe coupe1 = new Coupe("Audi R8", 250);
    Sedan sedan1 = new Sedan("Suzuki Ciaz", 180);
    Hatchback hatchback1 = new Hatchback("Hyundai Elantra", 170);
    List<Car> cars = new List<Car>(3);
    cars.Add(coupe1);
    cars.Add(sedan1);
    cars.Add(hatchback1);
    var orderedByTypeThenSpeedDescending = cars.OrderBy(x => x.GetType())
                                               .ThenByDescending(x => x.MaxSpeed);
