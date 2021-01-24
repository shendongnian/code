    public class ExtendedTagsQueryBuilder : TagsQueryBuilder
    {
      [QueryText("exact")]
      public bool Exact { get; set; }
    }
