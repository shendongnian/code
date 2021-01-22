    interface IOne 
    {
        void RaiseEventITwo();
        ITwo Two { get; set;}   
    }
    
    // note: left out some details
    class One : IOne
    {
        public One() { this.Two = new Two(); }    // Two implements ITwo
        public void RaiseEventITwo()
        {
            this.Two.OnLoadPage();   // i.e.: some event of ITwo is OnLoadPage
        }
    }
    
    // somewhere where you actually have the reference you speak off
    IOne one = new One();   // class One implements IOne
    one.RaiseEventITwo();
    
    // using the Mock<T> class:
    Mock<IOne> mockOne = new Mock<IOne>();
    mockOne.GetIOne().RaiseEventITwo();      // GetIOne needs to be implemented in 
                                             // Mock<T> or as extension for Mock<T>
