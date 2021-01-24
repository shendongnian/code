     Car CRV, Rogue, Prius;
     if (Car.ValidateCarModel(CarManufacturer.Honda, "CRV"))
     {
         CRV = new Car(CarManufacturer.Honda, "CRV");
     }
     if (Car.ValidateCarModel(CarManufacturer.Nissan, "Rogue"))
     {
         Rogue = new Car(CarManufacturer.Nissan, "Rogue");
     }
     //I know that Toyota makes a Prius, so I just create one.  If I mess up, I'll get an exception
     Prius = new Car(CarManufacturer.Toyota, "Prius");
