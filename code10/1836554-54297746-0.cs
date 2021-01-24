    public static class Rendering3D
    {
        public static bool IsOccluded(this Vector2 point, Matrix world) { }
    }
    static void Main()
    {
        Matrix world = ...
        Vector2 point = ...
        if( point.IsOccluded(world) )
        {
        }
        if( Rendering3D.IsOccluded(point, world) )
        {
        }
    }
