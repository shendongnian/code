    public class Stage
    {
        private List<Machine> _machines = new List<Machine>();
    
        public IEnumerable<Machine>
        {
            get { return _machines; }
        }
    
        public void AddMachine(Machine machine)
        {
            _machines.Add(machine);
            machine.AddStage(this);
        }
    
        public void RemoveMachine(Machine machine)
        {
            _machines.Remove(machine);
            machine.RemoveStage(this);
        }
    
        // etc.
    }
    
    public class Machine
    {
        private List<Stage> _stages = new List<Stage>();
    
        internal void AddStage(Stage stage)
        {
            _stages.Add(stage);
        }
    
        internal void RemoveStage(Stage stage)
        {
            _stage.Remove(stage);
        }
    
        // etc.
    }
