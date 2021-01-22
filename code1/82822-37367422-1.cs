    [Serializable]
    public class Schedule
    {
        public Schedule() : this(string.Empty, DateTime.MaxValue)
        {
        }
        public Schedule(string path, DateTime terminationTime)
        {
            path = driverPath;
            TerminationTime = terminationTime;
        }
        public DateTime TerminationTime { get; set; }
        public string Path { get; set; }
    }
    public sealed class Schedules : ApplicationSettingsBase
    {
        [UserScopedSetting]
        [SettingsSerializeAs(SettingsSerializeAs.Xml)]
        [DefaultSettingValue("")]
        public List<Schedule> Entries
        {
            get { return (List<Schedule>)this[nameof(Entries)]; }
            set { this[nameof(Entries)] = value; }
        }
    }
