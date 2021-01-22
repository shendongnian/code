    class City {...}
    public class FireNuclearMissileEventArgs : EventArgs
    {
        public FireNuclearMissileEventArgs(City city)
        {
            this.city = city;
        }
        private City city;
        public City City
        {
            get { return this.city; }
        }
    }
    public delegate void FireNuclearMissile(object sender, FireNuclearMissileEventArgs args);
    public event FireNuclearMissile FireNuclearMissileEvent;
    public class QueryPopulationEventArgs : EventArgs
    {
        public QueryPopulationEventArgs(City city)
        {
            this.city = city;
        }
        private City city;
        public City City
        {
            get { return this.city; }
        }
    }
    public delegate void QueryPopulation(object sender, QueryPopulationEventArgs args);
    public event QueryPopulation QueryPopulationEvent;
