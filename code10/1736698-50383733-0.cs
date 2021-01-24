    public class Transport
    {
       public virtual void Move() { Console.WriteLine("trans Moves"); }
    }
    public class AutoToTravelAdapter : Transport
    {
        private Auto auto = new Auto();
        private override void  Move()
        {
            auto.Drive();
        }
    }
