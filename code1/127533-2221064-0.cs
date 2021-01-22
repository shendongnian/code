    class Direct3DRenderer : IGraphicsRenderer
    {
       public void Render(List<Triangle> triangles);
    }
    
    class OpenGLRenderer: IGraphicsRenderer
    {
       public void Render(List<Triangle> triangles);
    }
