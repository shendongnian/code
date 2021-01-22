    public sealed class NewObject
    {
        private String Stuff { get; set; }
        // Use a method instead of a property because the operation is heavy.       
        public String GetAllStuff()
        {
            // Heavy string manipulation of this.Stuff.
            return this.Stuff;
        }
        // Or lets use a property because this.GetAllStuff() is not to heavy.
        public String AllStuff
        {
            get { return this.GetAllStuff(); }
        }
    
        public NewObject(String stuffToStartWith)
        {
            this.Stuff = stuffToStartWith;
        }
    
        public static NewObject operator +(NewObject obj1, NewObject obj2)
        {
            // Error handling goes here.
            return new NewObject(String.Concat(obj1.Stuff, obj2.Stuff);
        }
    }
