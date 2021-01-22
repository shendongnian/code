    class ChapterView
    {
      public int? GenChapter {get; set;}
      public int? QualChapter {get; set;}
      public int? DocumentId {get; set;}
    }
    
    private ChapterView GetChapterView()
    {
      return new ChapterView
      {
        GenChapter = ConvertNullable(Request.QueryString["gchap"]),
        QualChapter = ConvertNullable(Request.QueryString["qualchap"]),
        DocumentId = ConvertNullable(Request.QueryString["did"])
      }
    }
