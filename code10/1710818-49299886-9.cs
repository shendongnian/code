    public class AOSController: MonoBehaviour
    {
        public static event Action<AOSController> RaiseCreation;
        public static event Action<AOSController> RaiseDestruction;
        [SerializeField] private MoveController moveCtrl = null;
        Dictionary<string, Action> dict;
        void Start()
        {
            if(RaiseCreation != null) { RaiseCreation(this); }
            dict.Add("MoveLeft", this.moveCtrl.MoveLeft);
            dict.Add("MoveRight", this.moveCtrl.MoveRight);
        }
        void OnDestroy()
        {
            if(RaiseDestruction != null) { RaiseDestruction(this); }
        }
        public void Call(AOSCommand command)
        {
            if(dict.Contains(command.Method) == false){  return; } //Or debug
            // use the delay as well as you wish
            dict[command.Method]();
        }
    }
    public class MoveController: MonoBehaviour
    {
        private void MoveLeft(){}  
        private void MoveRight(){}
    }
