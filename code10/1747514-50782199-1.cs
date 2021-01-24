    public class Matrix<TVector> where TVector : Vector
    {
        public TVector[] rows = new TVector[2];
        public Matrix(TVector v1, TVector v2)
        {
            this.rows[0] = v1;
            this.rows[1] = v2;
        }
        public void Transform()
        {
            foreach (TVector v in rows)
            {
                Console.WriteLine(v.row[0]);
            }
        }
    }
