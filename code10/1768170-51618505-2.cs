    interface ISettingsHandler
    {
        void Handle(int value);
        bool CanHandle(string name);
    } 
    class GF1Handler : ISettingsHandler
    {
        public void Handle(int value){
            // do action
        }
        public bool CanHandle(string propertyName){
            return propertyName.Equals("GF1");
        }
    } 
    class GF2Handler : ISettingsHandler
    {
        public void Handle(int value){
            // do action
        }
        public bool CanHandle(string propertyName){
            return propertyName.Equals("GF2");
        }
    } 
