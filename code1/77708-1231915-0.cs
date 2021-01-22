    class Bus
    {
      private List<Passenger> passengers;
    
      // Never expose the original collection
      public IEnumerable<Passenger> Passengers
      {
         get { return passengers.Select(p => p); }  
      }
    
      // Or expose the original collection as read only
      public ReadOnlyCollection<Passenger> ReadOnlyPassengers
      {
         get { return passengers.AsReadOnly(); }
      }
      public void AddPassenger(Passenger passenger)
      {
         passengers.Add(passenger);
      }
     }
