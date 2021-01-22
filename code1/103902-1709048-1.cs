    public class LoggingThing : IMyInterface
    {
        private readonly IMyInterface innerThing;
        public LoggingThing(IMyInterface innerThing)
        {
            this.innerThing = innerThing;
        }
        public void DoStuff(string s)
        {
            this.innerThing(s);
            Log.Write("DoStuff", s);
        }
    }
