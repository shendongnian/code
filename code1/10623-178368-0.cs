    public interface ISteerable { SteertingWheel wheel { get; set; } }
    public interface IBrakable { BrakePedal brake { get; set; } }
    public class Vehicle : ISteerable, IBrakable
    {
        public SteeringWheel wheel { get; set; }
        public BrakePedal brake { get; set; }
 
        public Vehicle() { wheel = new SteeringWheel(); brake = new BrakePedal(); }
    }
    public static class SteeringExtensions
    {
        public static void SteerLeft(this ISteerable vehicle)
        {
            vehicle.wheel.SteerLeft();
        }
    }
    public static class BrakeExtensions
    {
        public static void Stop(this IBrakable vehicle)
        {
            vehicle.brake.ApplyUntilStop();
        }
    }
    public class Main
    {
        Vehicle myCar = new Vehicle();
        public void main()
        {
            myCar.SteerLeft();
            myCar.Stop();
        }
    }
