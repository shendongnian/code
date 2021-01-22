    class PointClass {
      int double X;
      int double Y;
    }
    
    class Circle {
      PointClass Center = new PointClass() { X = 0, Y = 0; }
    }
    
    static void Main() {
      Circle c = new Circle();
      Console.WriteLine(c.Center.X);
      c.Center.X = 42;
      Console.WriteLine(c.Center.X);
    }
