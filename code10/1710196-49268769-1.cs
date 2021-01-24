    public class Circle : Shape
    {
        double _radius;
        
        // Constructor for the Circle that has radius as a parameter
        public Circle(double radius)
        {
            _radius = radius;
        } 
        // Method that returns the area of the circle using radius value from constructor
        public double ShowArea() 
        {
            return Math.Pi * Math.Pow(_radius, 2.0);
        }
    }
