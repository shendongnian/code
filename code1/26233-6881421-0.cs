    private void SomeFunction()
    {
        List<VertexBasicTerrain> vertexList = GenerateVertices();
        short[] indexArray = GenerateIndices();
        CalculateNormals(vertexList, ref indexArray); // Will not work
        var vertexArray = vertexList.ToArray();
        CalculateNormals(ref vertexArray, ref indexArray);
    }
    // This works (algorithm from Reimers.net)
    private void CalculateNormals(ref VertexBasicTerrain[] vertices, ref short[] indices)
    {
        for (int i = 0; i < vertices.Length; i++)
            vertices[i].Normal = new Vector3(0, 0, 0);
        for (int i = 0; i < indices.Length / 3; i++)
        {
            Vector3 firstvec = vertices[indices[i * 3 + 1]].Position - vertices[indices[i * 3]].Position;
            Vector3 secondvec = vertices[indices[i * 3]].Position - vertices[indices[i * 3 + 2]].Position;
            Vector3 normal = Vector3.Cross(firstvec, secondvec);
            normal.Normalize();
            vertices[indices[i * 3]].Normal += normal;
            vertices[indices[i * 3 + 1]].Normal += normal;
            vertices[indices[i * 3 + 2]].Normal += normal;
        }
        for (int i = 0; i < vertices.Length; i++)
            vertices[i].Normal.Normalize();
    }
    // This does NOT work and throws a compiler error because of the List<T>
    private void CalculateNormals(List<VertexBasicTerrain> vertices, ref short[] indices)
    {
        for (int i = 0; i < vertices.Length; i++)
            vertices[i].Normal = new Vector3(0, 0, 0);
        for (int i = 0; i < indices.Length / 3; i++)
        {
            Vector3 firstvec = vertices[indices[i * 3 + 1]].Position - vertices[indices[i * 3]].Position;
            Vector3 secondvec = vertices[indices[i * 3]].Position - vertices[indices[i * 3 + 2]].Position;
            Vector3 normal = Vector3.Cross(firstvec, secondvec);
            normal.Normalize();
            vertices[indices[i * 3]].Normal += normal;
            vertices[indices[i * 3 + 1]].Normal += normal;
            vertices[indices[i * 3 + 2]].Normal += normal;
        }
        for (int i = 0; i < vertices.Length; i++)
            vertices[i].Normal.Normalize();
    }
