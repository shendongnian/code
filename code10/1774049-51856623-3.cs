    // The mesh. Assigned as you see fit.
    Mesh mesh;
    
    // The length of the new vertices array, holding every third vertex of a triangle.
    int length = 0; 
        
    // The new vertices array holding every third vertex.
    Vector3 [ ] vertices;
    
    void Start ( )
    {
        int [ ] triangles = mesh.triangles;
        length = triangles.Length / 3;
        vertices = new Vector3 [ length ];
    
        for ( int count = 0; count < length; count++ )
            vertices [ count ] = mesh.vertices [ triangles [ count * 3 ] ] ;
    }
    
    private void Update ( )
    {
        int j = 0;
        while ( j < length )
        {
            m_Particles [ j ].position = vertices [ j++ ];
        }
    }
