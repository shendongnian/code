    public class Train {        
        private string _trainID;
        public Train(string id) {
            _trainID = id;
        }
        //Get/Set for setting Train ID value.
        public string TrainID {
            get {
                return _trainID;
            }
            set {
                _trainID = value;
            }
        }
    }
