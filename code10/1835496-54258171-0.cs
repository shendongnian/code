    public class OuterHits
    {
      public string total {get;Set;}
    
      public string max_score {get;Set;}
    
      public List<RawDocument> hits {get;Set;} // or hits[]
    }
