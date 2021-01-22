    static void Main(string[] args)
            {
                List<Shape> shapes = new List<Shape>();
                shapes.Add(new Circle());
                shapes.Add(new Square());
                shapes.Add(new Rectangle());
    
                foreach (Shape s in shapes)
                    s.Draw();
    
                Console.Read();
            }
    
    public class Shape
        {
            public virtual void Draw() { }
    
        }
    
        public class Square : Shape
        {
            public override void Draw()
            {
                // Code to draw square
                Console.WriteLine("Drawing a square");
            }
        }
    
        public class Circle : Shape
        {
            public override void Draw()
            {
                // Code to draw circle
                Console.WriteLine("Drawing a circle");
    
            }
        }
    
        public class Rectangle : Shape
        {
            public override void Draw()
            {
                // Code to draw circle
                Console.WriteLine("Drawing a rectangle");
    
            }
        }
    
    *****Output:
    Drawing a circle
    Drawing a square
    Drawing a rectangle*****
