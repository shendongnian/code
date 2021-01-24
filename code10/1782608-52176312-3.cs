    public class Levellable: ILevellable
    {
        public event TypedEventHandler<ILevellable, LevellableChange> Changed;
        public int Level {
            get {
                return this._level;
            }
            private set {
                if (value != this._level) {
                    int oldLevel = this._level;
                    this._level = value;
                    this.Changed?.Invoke(this, new LevellableChange(value - oldLevel, 0));
                }
            }
        }
        private int _level;
        // similar for XP. 
    }
