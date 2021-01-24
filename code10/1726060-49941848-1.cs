    public class Speedboat : Boat 
    {
        public virtual List<ISpeedSource> SpeedSource { get; set; }
        public int Topspeed { get; set; }
    }
