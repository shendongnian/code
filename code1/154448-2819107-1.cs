    [WebMethod]
    public Car GetMyNewCar()
    {
        Car mycar = new SportsCar() { GirlFriend = "HiLo", TopSpeed = 300 };            
        return (Car)mycar.Clone();
    }
