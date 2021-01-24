    public interface ITag<T> : ITag
    {
      T OriginalValue { get; }
      T Value { get; set; }
      bool IsReadOnly { get; }
    }
    public class Tag<T> : Tag, ITag<T>
    {
      T currentValue;
      public Tag( T value, bool isReadOnly = true ) : base( )
      {
        IsReadOnly = isReadOnly;
        OriginalValue = value;
        currentValue = value;
      }
      public bool IsReadOnly { get; }
      public T OriginalValue { get; }
      public T Value
      {
        get
        {
          return currentValue;
        }
        set
        {
          if ( IsReadOnly ) throw new InvalidOperationException( "You should have checked!" );
          if ( Value != null && !Value.Equals( value ) )
          {
            currentValue = value;
            Notify( );
          }
        }
      }
    }
