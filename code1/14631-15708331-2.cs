    private sealed class Closure
    {
        public string[] files;
        public int i;
				
        public bool YourAnonymousMethod(string name)
        {
            return name.Equals(this.files[this.i]);
        }
    }
