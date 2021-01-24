    public class WeaponItem
    {
        public long PosseionTimeTicks {get;set;}
        public TimeSpan PossesionTime {get{ return new TimeSpan(PosseionTimeticks); }
    }
