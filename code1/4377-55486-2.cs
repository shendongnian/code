    public class Action {
        public string Name {get; private set;}
        public string Description {get; private set;}
    
        private Action(string name, string description) {
            Name = name;
            Description = description;
        }
    
        public static Action DoIt = new Action("Do it", "This does things");
        public static Action StopIt = new Action("Stop It", "This stops things");
    }
