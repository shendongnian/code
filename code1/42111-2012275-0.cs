    class Bus
    {
       IDriver busDriver = null;
       public void SetDriver(IDriver d) { busDriver = d; }
    }
    class Driver : IDriver
    {
       IShoePair shoes = null;
       public void PutShoesOn(IShoePair p) { shoes = p; }
    }
    class ShoePairWithDisposableLaces : IShoePair
    {
       Shoelace lace = new Shoelace();
    }
    class Shoelace : IDisposable
    {
       ...
    }
