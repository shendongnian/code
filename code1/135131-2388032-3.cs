    public class StateProvince
    {
        public string Code { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            StateProvince sp = obj as StateProvince;
            if (object.ReferenceEquals(sp, null))
                return false;
            return (sp.Code == Code);
        }
        public bool Equals(StateProvince sp)
        {
            if (object.ReferenceEquals(sp, null))
                return false;
            return (sp.Code == Code);
        }
        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("Code: [{0}]", Code);
        }
    }
