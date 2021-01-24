      struct MyDemo {
        public double x;
        public double y;
      }
      ...
      MyDemo a = new MyDemo() { x = double.NaN, y = double.NaN };
      MyDemo b = new MyDemo() { x = double.NaN, y = double.NaN };
      // Do struct equal to each other? (Yes)
      Console.WriteLine(a.Equals(b) ? "Yes" : "No");
      // Do structs' fields equal to each other? (No)
      Console.WriteLine(a.x == b.x && a.y == b.y ? "Yes" : "No");
