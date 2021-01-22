    public class Car
    {
        public Engine Engine { get; set; }
        public BrakePackage Brakes { get; set; }
        public SteeringPackage Steering { get; set; }
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        public void Accelerate( double pedalPressure )
        {
            this.Engine.MoveThrottle( pedalPressure, UpdatePosition );
        }
        public void UpdatePosition( double x, double y, double z, int deltaTime )
        {
            this.CalculateSpeed( this.X, this.Y, this.Z, x, y, z, deltaTime );
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        ...
    }
