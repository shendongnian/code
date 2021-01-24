    internal class Ship
    {
        private Welcome infoShowWelcome;
        private string port;
        private int peopleShip;
        public Ship(Welcome infoShowWelcome, string port, int peopleShip)
        {
            this.infoShowWelcome = infoShowWelcome;
            this.port = port;
            this.peopleShip = peopleShip;
        }
        internal void ShowInfo()
        {
            Console.WriteLine(this);
        }
    }
    internal class Plane
    {
        private Welcome infoShowWelcome;
        private int height;
        private int peoplePlane;
        public Plane(Welcome infoShowWelcome, int height, int peoplePlane)
        {
            this.infoShowWelcome = infoShowWelcome;
            this.height = height;
            this.peoplePlane = peoplePlane;
        }
        internal void ShowInfo()
        {
            Console.WriteLine(this);
        }
    }
    internal class Car
    {
        private Welcome infoShowWelcome;
        public Car(Welcome infoShowWelcome)
        {
            this.infoShowWelcome = infoShowWelcome;
        }
        internal void ShowInfo()
        {
            Console.WriteLine(this);
        }
    }
    internal class Vehicle
    {
        public Vehicle()
        {
        }
    }
    internal class Welcome
    {
        public Welcome()
        {
        }
        internal void ShowInfo(string nameTransport)
        {
            Console.WriteLine(this);
        }
    }
