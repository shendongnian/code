    class Solver
    {
      private double a;
      private double approximation;
      private Solver(double a) {
        this.a = a;
      }
 
      public static double Solve(double a)
      {
        Solver s = new Solver(a);
        s.Validate();
        s.Initialize();
        while (true) {
          if (s.WithinTolerances())
            return s.approximation;
          s.Refine();
        }
      }
      private void Validate() { ... }
      private void Initialize() { ... }
      private bool WithinTolerances() { ... }
      private void Refine() { ... }
