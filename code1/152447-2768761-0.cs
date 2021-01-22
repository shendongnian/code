    public class TopTitle
    {
      public int Span {get;set;}
      public string Value {get;set;}
      public int Position {get;set;}
    }
    
    public class SubTitle
    {
      public int Span {get;set;}
      public string Value {get;set;}
      public int Position {get;set;}
    }
    //
    List<Title> Titles = GetTitles();
    List<SubTitle> SubTitles = GetSubTitles();
    int i = 0;
    Titles.ForEach(t =>
    {
      t.Position = i;
      i += t.Span;
    }
    i = 0;
    SubTitles.ForEach(st =>
    {
      st.Position = i;
      i += st.Span;
    }
    
    var query =
      from t in Titles
      let sts =
        from st in SubTitles
        where t.Position <= st.Position
          && st.Position < (t.Position + t.Span)
      select st
      select new {Title = t, SubTitles = sts.ToList()};
