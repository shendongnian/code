    public class Setting 
    {
        public bool isActive { get; set; }
    }
    public static class Settings
    {
        public static Setting setting1 { get; set; } = new Setting { isActive = true };
        public static Setting setting2 { get; set; } = new Setting { isActive = false };
    }
    public class mWorker
    {
        private string wName;
        private Setting wSetting;
        public mWorker(string _name, Setting _setting)
        {
            wName = _name;
            wSetting = _setting;
        }
        public void doWork()
        {
            var onOff = wSetting.isActive ? "ON" : "OFF";
            Console.WriteLine($"Worker {wName} is turned {onOff}");
        }
    }
