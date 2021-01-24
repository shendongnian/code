    var vehicleValue = // array 1
    var vehicleCodeAndDescription = // array 2
    var options = //array 3
    
    var arr = Enumerable.Range(0, new int[]{vehicleValue.Length,vehicleCodeAndDescription.Length,options.Length}.Min())
                        .Select(i => Tuple.Create(vehicleValue[i], vehicleCodeAndDescription[i], options[i]))
                        .ToArray();
    foreach (var vehicleDetail in arr)
    {
        //do something
    }
