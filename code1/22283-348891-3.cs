    class Speed : Unit
    {
        public Speed(double x) : base(x, 0, 1, -1, ...); // m/s => m^1 * s^-1
        {
        }
    }
    class Acceleration : Unit
    {
        public Acceleration(double x) : base(x, 0, 1, -2, ...); // m/s^2 => m^1 * s^-2
        {
        }
    }
