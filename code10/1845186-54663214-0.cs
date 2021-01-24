    public struct Vector2
    {
       public float X;
       public float Y;
    }
    public class VectorWrapper
    {
       private Vector2 thing;
       public var X 
       {
            get { return thing.X; }
            set { thing.X = value; RaisePropertyChanged(SomePropertyName); }
       }
       public var Y 
       {
            get { return thing.Y; }
            set { thing.Y = value; RaisePropertyChanged(SomePropertyName); }
       }
    }
    
