    class Passenger
    {
         public string FirstName { get; set; }
         public string LastName { get; set; }
         public string Address { get; set; }
         public int Age { get; set; }
    
         void Passenger() {}
         void Passenger(string _firstName, string _lastName, string _address, int _age) 
         {
              this.FirstName = _firstName;
              this.LastName = _lastName;
              this.Address = _address;
              this.Age = _age; 
         }
    }
