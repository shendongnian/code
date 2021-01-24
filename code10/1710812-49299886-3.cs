    public class AOSDispatch : MonoBehaviour
    {
        Dictionary<string, Action> dict;
        void Start()
        {
            dict.Add("MoveLeft", MoveLeft);
            dict.Add("MoveRight", MoveRight);
        }
        public void Call(AOSCommand command)
        {
            if(dict.Contains(command.Method) == false){  return; } //Or debug
            // use the delay as well as you wish
            dict[command.Method]();
        }
        private void MoveLeft(){}  
        private void MoveRight(){}
    }
