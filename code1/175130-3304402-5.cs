    public enum Evilness
    {
        Slight,
        Moderate,
        Very,
    }
    class BoobyTrap : IDisposable
    {
        public Evilness Evil { get; protected set; }
        public BoobyTrap(Evilness evil)
        {
            this.Evil = evil;
        }
        public void DoEvil()
        {
            // ... snip (sorry, it's just too evil) ...
        }
        public static bool IsNull(BoobyTrap instance)
        {
            throw new Exception("I bet you thought this function would work, didn't you?  Well it doesn't!  You should know whether or not your variables are null.  Quit asking me!");
        }
        public static bool operator !=(BoobyTrap x, object y)
        {
            if(y == null)
                throw new Exception("You cannot check if an instance of a BoobyTrap is null using the != operator.  Mwahahaha!!!");
            return x.Equals(y);
        }
        public static bool operator ==(BoobyTrap x, object y)
        {
            if (y == null)
                throw new Exception("You cannot check if an instance of a BoobyTrap is null using the == operator.  Mwahahaha!!!");
            return x.Equals(y);
        }
        #region IDisposable Members
        public void Dispose()
        {
            switch (this.Evil)
            {
                case Evilness.Moderate:
                case Evilness.Very:
                    throw new Exception("This object is cursed.  You may not dispose of it.");
            }
        }
        #endregion
    }
