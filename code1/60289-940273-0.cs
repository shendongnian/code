    public class AlphaBeta : IAlpha, IBeta
    {
        string x {set;}
        string y {set;}
    }
    // too ambiguous
    AlphaBeta parkingLot = myFoo.Bar<AlphaBeta>();
