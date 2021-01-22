    public class FootballTeam : IDisposable
    {
        //...
        public void Dispose()
        {
            SomethingHappened -= this.HandleSomethingHappened;
            //release the reference to this instance so it can be GC'd
        }
    }
