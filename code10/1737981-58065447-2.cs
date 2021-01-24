    public class Book
    {
      public int Id { get; set; }
      public string Title { get; set; }
    }
    
    public class ResultSet<T>
    {
      public T[] Results { get; set; }
      public int TotalResultsCount { get; set; }
    }
    
    public class BookType : ObjectGraphType<Book>
    {
      public BookType()
      {
        Field(b => b.Id);
        Field(b => b.Title);
      }
    }
    
    public class ResultSetType<T, TType> : ObjectGraphType<ResultSet<T>>
      where TType : IGraphType
    {
      public ResultSetType()
      {
        Name = $"{typeof(TType).Name}ResultSet";
        Field<ListGraphType<TType>>("results");
        Field<IntGraphType>("totalResultsCount");
      }
    }
