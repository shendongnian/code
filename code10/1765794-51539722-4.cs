        class Program
        {
            static void Main(string[] args)
            {
                IStubClock fakeClock = new FakeClock(new DateTime(1, 1, 1, 10, 0, 0)); //time is set to 10am
                IStubClock realClock = new RealClock(); //time is set to whatever the time now is.
                Hotel hotel1 = new Hotel(fakeClock); //using fake time
                Hotel hotel2 = new Hotel(realClock); //using the real time
            }
        }
