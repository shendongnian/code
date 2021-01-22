    int[][] a = new int[6][];//its mean num of row is 6
            int choice;//thats i left on user choice that how many number of column in each row he wanna to declare
            
            for (int row = 0; row < a.Length; row++)
            {
               Console.WriteLine("pls enter number of colo in row {0}", row);
               choice = int.Parse(Console.ReadLine());
                a[row] = new int[choice];
                for (int col = 0; col < a[row].Length; col++)
                {
                    a[row][col] = int.Parse(Console.ReadLine());
                }
            }
