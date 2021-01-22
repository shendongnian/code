    class GameComponent
    {
        public virtual string Name
        {
            // You could also hard-code this or cache it
            // for better performance.
            get { return this.GetType().Name; }
        }
    }
