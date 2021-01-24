    interface IConveyor 
    {
        void ConveyStuff();
    }
   
    class Simulator<T> 
    {
        void Simulate(T thingToSimulate)
        {
            //Do something to simulate
        }
    }
    class RealConveyor : IConveyor
    {
        public void ConveyStuff()
        {
        }
    }
    class SimulatedConveyor<IConveyor> : Simulator, IConveyor
    {
        public void ConveyStuff()
        {
            Simulate(this);
        }
    }
