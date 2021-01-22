    public ReadOnlyCollection<IReadOnlyVector2> Vertices
    {
        get { return _vertices.Cast<IReadOnlyVector2>().ToList().AsReadOnly(); }
    }
    List<Vector2> _vertices;
    interface IReadOnlyVector2 {
     .. only RO getters and no setters
    }
    
    class Vector2 : IReadOnlyVector2{
    .
    .
    .
