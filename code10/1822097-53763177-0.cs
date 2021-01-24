    public void Add_passenger()
    {
           var PassengerList=new List<int>(Passenger);
           Console.WriteLine("Enter age of passenger");
           PassengerList.Add(int.Parse(Console.ReadLine()));
           Passenger=PassengerList.ToArray();
    }
  
