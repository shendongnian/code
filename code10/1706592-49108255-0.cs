    public class BaseCreature<THead> where THead : BaseHead 
    {
        public THead Head { get; set; }
        public BaseCreature(THead head)
        {
            this.Head = head;
        }       
    }
