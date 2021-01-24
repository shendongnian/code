    public class PolyVar
    {
        protected string _myValue;
        public PolyVar() { this._myValue = ""; }
        public PolyVar(string value) { this._myValue = value; }
        public string Value { get => this._myValue; set => this._myValue = value; }
        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
