    public class Car
    {
        public Car(int initialSpeed)
        {
            Speed = initialSpeed;
        }
        public int Speed { get; set; }
        public void MultiplySpeed(int multiply)
        {
            Speed *= multiply;
        }
    }
