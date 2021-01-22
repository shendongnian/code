    public interface IAlerts { 
        void Show(string message);
    }
    
    public class EventLogAlerts : IAlerts { ... }
    public class WindowsAlerts : IAlerts { ... }
    
    public class ConsoleAlerts : IAlerts { ... }
    public class MyLibrary {
        private IAlerts alertImpl = new EventLogAlerts();
        public void SetUserInterface(IMyUserInterface impl) 
        {
            this.alertImpl = impl;
        }
        public void DoSomething()
        {
            try 
            {
                ...
            }
            catch (Exception)
            {
                this.alertImpl.Show("Whoops!");
            }  
        }
    }
