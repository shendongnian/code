    public delegate int DriveMeWithSpeed(int maxForceOnPedal);
        public class Car
        {
            DriveMeWithSpeed speedy;
    
            public Car(DriveMeWithSpeed YourSpeed)
            {
                speedy = YourSpeed;
            }
    
            public void Drive()
            {
                if (speedy != null) speedy(100);
            }
    
        }
        public class Person
        {
            public int IDrive(int PedalForce)
            {
                return 40;
            }
        }
        public static void Main(string[] args)
            {
                Person Me = new Person();
    
                Car myCar = new Car(Me.IDrive);
                myCar.Drive();
            }
