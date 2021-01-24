    public class Car<T> : IVehicle where T : Fuel
    {
        private Engine<T> engine = new Engine<T>();
       
        public void StartEngine()
        {
            engine.Start();
        }
    }
