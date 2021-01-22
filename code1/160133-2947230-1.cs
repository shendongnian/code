    public class Thing {
        public Thing () : This (ID: 0) {}
        public Thing (int ID) {
            this._ID = ID
        }
        private readonly int _ID;
        public int ID {
            get { return this._ID;};
        }
    }
