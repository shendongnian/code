    public class GameStateVm
    {
        public int Id { set;get;}
        public string State { set;get;}
    }
    public class SaveGameVm
    {
        public GameStateVm[] Character { set;get;}
        public bool PFlag { set;get;}
    }
