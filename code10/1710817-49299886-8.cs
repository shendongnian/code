    public class AOSDispatch:MonoBehaviour
    {
         private IDictionary<string, AOSController> dict;
         void Awake(){
               this.dict = new Dictionary<string, AOSController>(); 
               AOSController.RaiseCreation += ProcessCreation;
               AOSController.RaiseDestruction += ProcessDestruction;
         }
        void OnDestroy()
        {
               AOSController.RaiseCreation -= ProcessCreation;
               AOSController.RaiseDestruction -= ProcessDestruction;
        }
        private void ProcessCreation(AOSController controller){
             this.dict.Add(controller.name, controller);
        }
        private void ProcessDestruction(AOSController controller){
             AOSController temp= null;
             if(this.dict.TryGetValue(controller.name, out temp) == true){
                 this.dict.Remove(name);
            }
        }
        private void ProcessCommand(AOSCommand command)
        {
            AOSController controller = null;
            if(this.dict.TryGetValue(command.ObjName, out controller) == true){
                 controller.Call(command);
                 return;
            }
        }
    }
