    using System;
    using System.Collections.Generic;
    using System.Linq;
    static class Program
    {
        static void Main()
        {
            int[][] data = {
              new[]{4,1,8,0,3,2,6},
              new[]{7,0,4,9,1,1,5},
              new[]{0,6,1,3,5,2,0}};
            int[] sortCols = { 5, 2, 0, 3 };
    
            IEnumerable<int[]> qry = data;
            if (sortCols.Length > 0)
            {
                IOrderedEnumerable<int[]> sorted =
                    qry.OrderBy(row => row[sortCols[0]]);
                for (int i = 1; i < sortCols.Length; i++)
                {
                    int col = sortCols[i]; // for capture
                    sorted = sorted.ThenBy(row => row[col]);
                }
                qry = sorted;
            }
            
            // show results (does actual sort when we enumerate)
            foreach (int[] row in qry)
            {
                foreach (int cell in row)
                {
                    Console.Write(cell);
                    Console.Write('\t');
                }
                Console.WriteLine();
            }
        }
    }
