    public class ClocksList : List<Clock>
    {
       public void MoveSingleClock(Clock clock)
       {
          clock.MoveTime();
       }
  
       public void MoveAllClocks()
       {
          foreach(clock c in InnerList)
          {
             MoveSingleClock(c);
          }      
       }
    }
