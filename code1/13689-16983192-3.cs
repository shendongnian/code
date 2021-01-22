    public class matrix
    {
        public List<List<double>> mat;
        public int rows,cols;
        public matrix clone()
        { 
            // create new object
            matrix copy = new matrix();
            // firstly I can directly copy rows and cols because they are value types
            copy.rows = this.rows;  
            copy.cols = this.cols;
            // but now I can no t directly copy mat because it is not value type so
            int x;
            // I assume I have clone method for List<double>
            for(x=0;x<this.mat.count;x++)
            {
                copy.mat.Add(this.mat[x].clone());
            }
            // then mat is cloned
            return copy; // and copy of original is returned 
        }
    };
