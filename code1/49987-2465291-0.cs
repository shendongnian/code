    public class MyDTO {
      public string BeeName { get; set; }
      public string AId { get; set; }
    }
    
    // .. (snip) ..
    
    ICriteria criteria = ActiveRecordMediator<B>.GetSessionFactoryHolder()
      .CreateSession(typeof(B)).CreateCriteria(typeof(B))
      .CreateCriteria(“A”)
      .SetProjection(Projections.ProjectionList()
        .Add(Projections.Property("bname", "BeeName"))
        .Add(Projections.Property("aid", "AId"))
      )
      .SetResultTransformer(Transformers.AliasToBean(typeof(MyDTO)));
    
    IList<MyDTO> results = criteria.List<MyDTO>();
