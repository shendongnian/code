    public class NetworkArg : System.EventArgs
    {
        public Thing thing { get; private set;}
        public NetworkArg(Thing thing){ this.thing = thing; }
    }
