    public class Mesh
    {
        public Mesh(int n)
        {
            this.Size = n;
            this.Cells = new double[n, n];
        }
        public int Size { get; }
        public double[,] Cells { get; }
        public double CellRadius { get; } = 1;
        /// <summary>
        /// Peform inertpolation among cells.
        /// </summary>
        public double Value(double x, double z)
        {
            //   |          |
            // --*----------*-----------> x
            //   | v(i,j)   | v(i,j+1)
            //   |          |
            //   |          |
            // --*----------*--
            //   | v(i+1,k) | v(i+1,j+1)
            //   |
            //   v 
            //   z
            // Find top left cell location
            double h = CellRadius;
            int i = (int)Math.Floor(z/h);
            if(i>=Size-1) { i=Size-2; }
            int j = (int)Math.Floor(x/h);
            if(j>=Size-1) { j=Size-2; }
            var v_11 = Cells[i, j];
            var v_12 = Cells[i, j+1];
            var v_21 = Cells[i+1, j];
            var v_22 = Cells[i+1, j+1];
            x -= j*h;
            z -= i*h;
            var ξ = x/h; //pre compute ratio for speed
            var v_1 = (1-ξ)*v_11 + (ξ)*v_12;
            var v_2 = (1-ξ)*v_21 + (ξ)*v_22;
            var ζ = z/h; //pre compute ratio for speed
            return (1-ζ)*v_1 + (ζ)*v_2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var mesh = new Mesh(3);
            mesh.Cells[0, 0] = 1;
            mesh.Cells[0, 1] = 2;
            mesh.Cells[0, 2] = 2;
            mesh.Cells[1, 0] = 1;
            mesh.Cells[1, 1] = 1;
            mesh.Cells[1, 2] = 2;
            mesh.Cells[2, 0] = 0;
            mesh.Cells[2, 1] = 1;
            mesh.Cells[2, 2] = 0;
            Console.WriteLine($"{"x",12} {"z",12} {"v",12}");
            for(int i = 0; i < 10; i++)
            {
                var x = 1.2;
                var z = 3.0*i/9;
                var v = mesh.Value(x, z);
                Console.WriteLine($"{x,12:g6} {z,12:g6} {v,12:g6}");
            }
        }
    }
