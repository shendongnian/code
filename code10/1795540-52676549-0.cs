	        int[][] arr = new int[2][];// Declare the array  
            int[] arr1 = new int[4];
            int[] arr2 = new int[6];
            //user input for arr1
            for (int i = 0; i < arr1.Length;i++ )
            {
                arr1[i] = int.Parse(Console.ReadLine());
            }
            // user input for arr2
            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = int.Parse(Console.ReadLine());
            }
            arr[0] = arr1;
            arr[1] = arr2;
                // Traverse array elements  
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < arr[i].Length; j++)
                    {
                        System.Console.Write(arr[i][j] + " ");
                    }
                    System.Console.WriteLine();
                }
