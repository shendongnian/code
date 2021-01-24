    public struct Nullable<T> where T : struct
    {
        private bool hasValue; 
        internal T value;
 
        [System.Runtime.Versioning.NonVersionable]
        public Nullable(T value) {
            this.value = value;
            this.hasValue = true;
        }        
