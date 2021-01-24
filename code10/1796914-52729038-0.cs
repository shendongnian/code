    //Your existing code
    Car car = context.Cars.Single(a => a.CarId == id);
    DescriptionCar descriptionCar = new DescriptionCar();
    //Code to save a new description to your ICollection
    List<DescriptionCar> descriptions = new List<DescriptionCar>(); //List to work with
    
    if (car.DescriptionCars!= null) 
    {
      descriptions = (List<DescriptionCar>)car.DescriptionCars; //Load existing ICollection into our List
    }
    
    descriptions.Add(descriptionCar); //Add the new description
    car.DescriptionCars = descriptions; //Store the working list into the EF object
    context.Save(); //Save to the database
