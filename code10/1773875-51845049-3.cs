        class Solution
        {
            static int[] foo(int[] array)
            {
            int[] xx = new int[array.Length];
            //Copy the array into the new array
            Array.Copy(array, xx, array.Length);  
                for (int i = 0; i < xx.Length; i++)
                {
                    xx[i] *= 2; 
                    Console.WriteLine(xx[i]);
                }
                return xx;
            }
            static void Main(string[] args)
            {
                int[] array = new int[4] { 73, 67, 38, 33 };
                //Assign the new array to an object
                int[] newArray = foo(array);
            }
        }
