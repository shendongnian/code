    public class ParameterizedProperty<typeReturn, typeIndexer> {
        private Dictionary<typeIndexer, typeReturn> oReturn = new Dictionary<typeIndexer, typeReturn>();
    
        public typeReturn this[typeIndexer oIndexer] {
            get { return oReturn[oIndexer]; }
            set { oReturn[oIndexer] = value; }
        }
    }
