    public class AllThoseBooleans {
        // expose values
        public bool walkable => actual.walkable;
        public bool current => actual.current;
        public bool target => actual.target;
        // real values defined here.
        private class Actuals {
            private bool walkable {get; set;}
            private bool current {get; set;}
            private bool target {get; set;}
        }
        private Actuals actual {get; set;} = new Actuals();
        // reset all values to default by initialization
        public void ResetAll() {
            actual = new Actuals();
        }
    }
