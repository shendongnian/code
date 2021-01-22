    [struct|class] Point {
        public int x, y;
        
        public Point(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }
    Point p = new Point(1, 1);
    object o = p;
    p.x = 2;
    Console.WriteLine(((Point)o).x);
