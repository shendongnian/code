    public class IsActiveWrapper
    {
        private bool isActive;
    
        public string Value
        {
            get
            {
                return isActive ? "Y" : "N";
            }
    
            set
            {
                isActive = "Y".Equals(value);
            }
        }
    
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
    
        public static implicit operator IsActiveWrapper(bool isActive)
        {
            return new IsActiveWrapper { IsActive = isActive };
        }
    
        public static implicit operator bool(IsActiveWrapper wrap)
        {
            if (wrap == null) return false;
            return wrap.IsActive;
        }
    }
    
