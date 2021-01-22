    class MyResourcePolicy : IResourcePolicy {
        private string version;
    
        public string Version {
            get {
                return this.version;
            }
            set {
                this.version = value;
            }
        }
    }
