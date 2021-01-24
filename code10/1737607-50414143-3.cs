    public class C
    {
        public DateTime DateCreated 
        {
            set
            {
                this.A.DateCreated = value;
                this.B.DateCreated = value;
            }
        }
    }
