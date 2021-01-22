    using System;
    
    public abstract class DrivingState
    {
        public static readonly DrivingState Neutral = new NeutralState();
        public static readonly DrivingState Drive = new DriveState();
        public static readonly DrivingState Parking = new ParkingState();
        public static readonly DrivingState Reverse = new ReverseState();
        
        // Only nested classes can derive from this
        private DrivingState() {}
        
        public abstract void Go();
        
        private class NeutralState : DrivingState
        {
            public override void Go()
            {
                Console.WriteLine("Not going anywhere...");
            }
        }
    
        private class DriveState : DrivingState
        {
            public override void Go()
            {
                Console.WriteLine("Cruising...");
            }
        }
        
        private class ParkingState : DrivingState
        {
            public override void Go()
            {
                Console.WriteLine("Can't drive with the handbrake on...");
            }
        }
    
        private class ReverseState : DrivingState
        {
            public override void Go()
            {
                Console.WriteLine("Watch out behind me!");
            }
        }
    }
