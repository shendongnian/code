    public class City {...}
    public delegate void FireNuclearMissile(object sender, EventArgs<City> args);
    public event FireNuclearMissile FireNuclearMissileEvent;
    public delegate void QueryPopulation(object sender, EventArgs<City> args);
    public event QueryPopulation QueryPopulationEvent;
