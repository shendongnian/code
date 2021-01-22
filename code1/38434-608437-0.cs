    public struct Point3D {
    
       public float X { get; private set; }
       public float Y { get; private set; }
       public float Z { get; private set; }
    
       public Point3D(float x, float y, float z) {
          X = x;
          Y = y;
          Z = z;
       }
    
       public Point3D Invert() {
          return new Point3D(-X, -Y, -Z);
       }
    
    }
