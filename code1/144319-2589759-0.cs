    interface ICanDraw {
        void Draw(ArrayList<Point> allPoints);
    }
    public abstract class Point : ICanDraw {
        ...
    }
    public PoniePoint : Point {
        public void Draw(ArrayList<Point> allPoints) {
            // do drawing logic here
        }
    }
