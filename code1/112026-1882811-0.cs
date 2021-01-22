    public class FootballTeam
    {
        private static event EventHandler SomethingHappened;
        public FootballTeam()
        {
            SomethingHappened += this.HandleSomethingHappened;
        }
        public void DoSomething()
        {
            SomethingHappened(); //notifies all instances - including this one!
        }
    }
