    using System;
    
    public class Gizmo
    {
        public int Foo { set; get; }
        public double Bar { set; get; }
    
        public Gizmo(int f, double b)
        {
            Foo = f;
            Bar = b;
        }
    }
    
    class Demo
    {
        static void ShowGizmo(Gizmo g = null)
        {
            Gizmo gg = g ?? new Gizmo(12, 34.56);
            Console.WriteLine("Gizmo: Foo = {0}; Bar = {1}", gg.Foo, gg.Bar);
        }
    
        public static void Main()
        {
            ShowGizmo();
            ShowGizmo(new Gizmo(7, 8.90));
        }
    }
