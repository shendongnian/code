    public class Face: IFace
    {
        public int NoseSize
        {
            get;
            set;
        }
    
        public void foo()
        {
            this.NoseSize = 42;
            int someSize = this.NoseSize;
        }
    }
