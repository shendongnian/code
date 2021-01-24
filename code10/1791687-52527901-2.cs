        public interface ISettings
        {
            bool MySetting { get; set; }
        }
        public class Settings: ISettings
        {
            public bool MySetting { get; set; } = true;
        }
        public class mWorker
        {
            private string wName;
            private ISettings settings;
            public mWorker(string _name, ISettings settings)
            {
                wName = _name;
                this.settings = settings;
            }
            public void doWork()
            {
                var onOff = (settings.MySetting) ? "ON" : "OFF";
                Console.WriteLine($"Worker {wName} is turned {onOff}");
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var settingsForWorker1 = new Settings() { MySetting = true };
                mWorker worker1 = new mWorker("W1", settingsForWorker1);
                var settingsForWorker2 = new Settings() { MySetting = false };
                mWorker worker2 = new mWorker("W2", settingsForWorker2);
                Console.WriteLine("\n=====================");
                worker1.doWork();   // Result: "Worker W1 is turned ON"
                worker2.doWork();   // Result: "Worker W2 is turned OFF"
                settingsForWorker1.MySetting = false;
                settingsForWorker2.MySetting = true;
                Console.WriteLine("\n=====================");
                worker1.doWork();   // Desired result: "Worker W1 is turned OFF"
                worker2.doWork();   // Desired result: "Worker W2 is turned ON"
                Console.ReadLine();
            }
        }
