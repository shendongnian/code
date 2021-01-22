    public class Triggerific
    {
        public event EventHandler Trigger;
        private static void OnTriggerTriggered(object sender, EventArgs e)
        {
            Console.WriteLine("Triggered!");
        }
        public void AddTrigger()
        {
            Trigger += OnTriggerTriggered;
        }
    }
