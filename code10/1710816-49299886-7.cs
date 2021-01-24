    public class AOSDispatch : MonoBehaviour
    {
        [SerializeField] private MoveController moveCtrl = null;
        Dictionary<string, Action> dict;
        void Start()
        {
            dict.Add("MoveLeft", this.moveCtrl.MoveLeft);
            dict.Add("MoveRight", this.moveCtrl.MoveRight);
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
