    public static List<Vector2> Wavefronts(Vertex[] vertices, float s)
    {
        var result = new List<Vector2>(vertices.Length);
        for (int i = 0; i < vertices.Length; i++)
        {
            result[i] = vertices[i].o + vertices[i].v * s;
        }
        return result;
    }
