    public class Matrix
    {
        //so now this array of vector will be of class Vector
        public Vector[] rows = new Vector[2];
        public Matrix(Vector v1, Vector v2){
            this.rows[0] = v1;
            this.rows[1] = v2;
        }
        public void Transform()
        {
            foreach (Vector v in rows)
            {
                Console.WriteLine(v.row[0]);
            }
        }
    }
