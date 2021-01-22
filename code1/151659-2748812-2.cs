    public ReadOnlyCollection<IReadOnlyVector2> Vertices
    {
        get { return (from v in _vertices 
                      select new DerivedVector2 { WrappedVector2 = v })
                     .Cast<IReadOnlyVector2>().ToList().AsReadOnly(); 
         }
    }
    List<Vector2> _vertices;
    interface IReadOnlyVector2 {
     .. only RO getters and no setters
    }
    
    class DerivedVector2 : IReadOnlyVector2{
        public Vector2 WrappedVector2 { get; internal set;} 
    .
    .
    .
