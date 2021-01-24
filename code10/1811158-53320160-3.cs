    public class Container : B<Item>
    {
       public int J { get; set; }
       public List<Item> KLM { get; set; } 
       IEnumerable<A> B.KLM => KLM;
    }
