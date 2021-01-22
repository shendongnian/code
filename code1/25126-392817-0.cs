    public class Seat
    {
      public void SeatPerson(Person person, Action successAction)
      {
        if (IsAccepted(person))
        {
          this.Seated = person;
          successAction();
        }
      }
    }
    
    
    public class Person
    {
      public void Sit(Seat seat)
      {
        seat.SeatPerson(this, this.SitComplete);
      }
    
      public void SitComplete()
      {
        this.Status = Sitting;
      }
    }
