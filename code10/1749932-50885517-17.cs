    public class Program
    {
        public static void Main(string[] args)
        {
            Drawing myDrawing3D = new Drawing3D("Sketch 3D", 10, 12, 14);
            myDrawing3D.Print();
            Drawing myDrawing2D = new Drawing2D("Sketch 2D", 10, 12);
            myDrawing2D.Print();
            Console.WriteLine("Done");
        }
    }
