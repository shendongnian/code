    public class Question
    {
        public string ID { get; set; }
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
        public override bool Equals(System.Object obj)
        {
            return (obj != null && obj is Question) ? (this.ID == ((Question)(obj)).ID) : false;
        }
    }
