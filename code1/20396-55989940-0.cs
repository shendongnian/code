        public interface IPointF{
            float X { get; }
            float Y { get; }
        }
    
        public struct PointF: IPointF{
            public PointF(float x, float y){
                X=x;Y=y;
            }
            public float X { get; private set; }
            public float Y { get; private set; }
        }
        
        public static class PointHelper{
            public static PointF ADD(this IPointF p, float val){
                return new PointF(p.x+val, p.y+val);
            }
        }
