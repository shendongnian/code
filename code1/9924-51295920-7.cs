	public class MachineName : Composition<string> {
		public MachineName(string s) : base(s) { }
		public MachineName(MachineName mn) : base(mn.Value) { }
    
		public bool Equals(MachineName o) => object.Equals(this, o); 
        public static bool operator ==(MachineName o1, MachineName o2) => object.Equals(o1, o2);	
        public static bool operator !=(MachineName o1, MachineName o2) => !object.Equals(o1, o2);
	}
