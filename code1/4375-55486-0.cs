    public class Action {
        public string Name {get;}
        public string Description {get;}
    
        private Action(string name, string description) {
            Name = name;
            Description = description;
        }
    
        public static Action DoIt = new Action("Do it", "This does things");
        public static Action StopIt = new Action("Stop It", "This stops things");
    }
