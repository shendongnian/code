    public class ConvertTable<TOuter, TInner>
        where TInner : class
        where TOuter : class
      {
        public TOuter FromT { get; set; }
        public TInner InnerT { get; set; }
        public ConvertTable(TOuter fromT, TInner innerT)
        {
          FromT = fromT;
          InnerT = innerT;
        }
      }
