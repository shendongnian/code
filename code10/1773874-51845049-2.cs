        class Solution
        {
            static int[] foo(int[] array)
            {
                int[] xx = new int[array.Length]; // Building this but not using it
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] *= 2; //Altering the input array changes the array in the Main method..
                    Console.WriteLine(array[i]);
                }
                return array;
            }
            static void Main(string[] args)
            {
                int[] array = new int[4] { 73, 67, 38, 33 };
                foo(array); // Not assigning the values to an object.
                //After this step look at array it will be 146, 134, 76 , 66
            }
        }
