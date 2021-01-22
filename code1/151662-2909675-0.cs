    List<Vector2> _vertices;
    public IEnumerable<Vector2> Vertices
    {
        get
        {
            foreach (Vector2 vec in _vertices)
                yield return vec;
        }
    }
