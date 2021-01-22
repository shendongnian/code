    // Declare a new list of vertices
    List<Vertex> vertices = new List<Vertex>();
    
    // Add a couple of vertices
    vertices.Add(new Vertex(0, 0, 0));
    vertices.Add(new Vertex(1, 100, 100));
    vertices.Add(new Vertex(2, 50, 50));
    
    // Get a vertex back out of the list by using its index
    Vertex temp = vertices[1]; // this is the second vertex we added above
