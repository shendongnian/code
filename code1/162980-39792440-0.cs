    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;    
    
    namespace MatrixTest
    {
    public class Matrix
    {
        private int dimension; //number of rows & colums for matrix
        private double[][] matrix; //holds values of matrix itself
        /// <summary>
        /// Create dim*dim matrix and fill it with data passed to this constructor.
        /// </summary>
        /// <param name="double_array"></param>
        /// <param name="dim"></param>
        public Matrix(double[][] double_array)
        {
            matrix = double_array;
            dimension = matrix.Length;
            // check square matrix:
            for (int i = 0; i < dimension; i++)
                if (matrix[i].Length != dimension)
                    throw new Exception("Matrix is not square");
        }
        /// <summary>
        /// Get determinant of current matrix
        /// </summary>
        /// <returns></returns>
        public double Determinant()
        {
            if (dimension == 1)
                return matrix[0][0];
            // else ricorsive call:
            double det = 0;
            for (int j = 0; j < dimension; j++)
            {
                if (j % 2 == 0)
                    det += matrix[0][j] * GetSubmatrix(this, 0, j).Determinant();
                else
                    det -= matrix[0][j] * GetSubmatrix(this, 0, j).Determinant();
            }
            return det;
        }
        /// <summary>
        /// Return a new Matrix with:
        /// dimension = passed matrix dimension - 1
        /// elements = all element of the original matrix, except row and column specified
        /// </summary>
        /// <param name="m"></param>
        /// <param name="rowToExclude"></param>
        /// <param name="colToExclude"></param>
        /// <returns></returns>
        public Matrix GetSubmatrix(Matrix m, int rowToExclude, int colToExclude)
        {
            double[][] values = new double[m.dimension - 1][];
            for (int i = 0; i < m.dimension; i++)
            {
                // create row array:
                if (i < m.dimension - 1)
                    values[i] = new double[m.dimension - 1];
                // copy values:
                for (int j = 0; j < m.dimension; j++)
                    if (i != rowToExclude && j != colToExclude)
                        values[i < rowToExclude ? i : i - 1][j < colToExclude ? j : j - 1] = m.matrix[i][j];
            }
            return new Matrix(values);
        }
        internal class Program
        {
            private static void Main(string[] args)
            {
                Matrix mat02 = new Matrix(
                    new double[][] {
                    new double[] { 1.0, 2.0},
                    new double[] { -2.0, -5.0} });
                Matrix mat03 = new Matrix(
                    new double[][] {
                    new double[] { 1.0, 2.0, -1.0 },
                    new double[] { -2.0, -5.0, -1.0},
                    new double[] { 1.0, -1.0, -2.0 } });
                Matrix mat04 = new Matrix(
                    new double[][] {
                    new double[] {1.0, 2.0, 1.0, 3.0},
                    new double[] { -2.0, -5.0, -2.0, 1.0 },
                    new double[] { 1.0, -1.0, -3.0, 2.0 },
                    new double[] {4.0, -1.0, -3.0, 1.0} });
                Matrix mat05 = new Matrix(
                    new double[][] {
                    new double[] {1.0, 2.0, 1.0, 2.0, 3.0},
                    new double[] {2.0, 1.0, 2.0, 2.0, 1.0},
                    new double[] {3.0, 1.0, 3.0, 1.0, 2.0},
                    new double[] {1.0, 2.0, 4.0, 3.0, 2.0},
                    new double[] {2.0, 2.0, 1.0, 2.0, 1.0} });
                double determinant = mat02.Determinant();
                Console.WriteLine("determinant is: {0}", determinant);
                determinant = mat03.Determinant();
                Console.WriteLine("determinant is: {0}", determinant);
                determinant = mat04.Determinant();
                Console.WriteLine("determinant is: {0}", determinant);
                determinant = mat05.Determinant();
                Console.WriteLine("determinant is: {0}", determinant);
                Console.ReadLine();
            }
        }
    }
}
