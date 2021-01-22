    public class X
    {
        private bool locked = false;
        private int lockedVar;
        public int LockedVar
        {
            get { return lockedVar; }
            set { if (!locked) lockedVar = value; }
        }
 
        public void LockObject() { locked = true; }
        public void UnlockObject() { locked = false; }
    }
