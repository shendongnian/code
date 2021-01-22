    public class HolidayMap : ClassMap<Holiday>
    {
        public HolidayMap()
        {
            Id(x => x.HolidayID).SetAttribute("type", "Int64");
            Map(x => x.Name);
            Map(x => x.Day);
            Map(x => x.Month);
            Map(x => x.IsActive);
            HasOne(x => x.Group);
        }
    }
