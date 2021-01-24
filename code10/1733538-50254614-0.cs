    public struct volt
    {
        private string[] _volts = new string[4];
        public string[] volts {get {return _volts;} }
        public string volt1 {
           get {return _volts[0];}
           set {_volts[0] = value;}
        }
        public string volt2 {
           get {return _volts[1];}
           set {_volts[1] = value;}
        }
        public string volt3 {
           get {return _volts[2];}
           set {_volts[2] = value;}
        }
        public string volt4 {
           get {return _volts[3];}
           set {_volts[3] = value;}
        }
    }
    private class Injection
    {
        private _volt[] = new volt[5];
        public volt[] {get {return _volt;} }
        public volt stru1 {
            get {return _volt[0];}
            set {_volt[0] = value;}
        }
        public volt stru2 {
            get {return _volt[1];}
            set {_volt[1] = value;}
        }
        public volt stru3 {
            get {return _volt[2];}
            set {_volt[2] = value;}
        }
        public volt stru4 {
            get {return _volt[3];}
            set {_volt[3] = value;}
        }
        public volt stru5 {
            get {return _volt[4];}
            set {_volt[4] = value;}
        }
        public volt stru6 {
            get {return _volt[5];}
            set {_volt[5] = value;}
        }
    }
