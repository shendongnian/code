    class Program
    {
        /*
        I assume you are trying to
        1. Create an array of integers
        2. Store random numbers (between 0 and 100) inside that array
        3. Print the numbers in the array 
        You have alot of reading to do as theres alot of fundemental mistakes in both your approach and code.
         */
        static void Main(string[] args)
        {
            // creating an array with random numbers
        ArrayMethods m = new ArrayMethods();
        int[] nums1; 
        nums1 = m.CreateRandomlyFilledArray(10);          
        m.Printarray(nums1);
        }
        class ArrayMethods
        {
            /*
                 - First you have to fill the array with random numbers
            In your solution, you have created "CreateRandomlyFilledArray".
             1. You created the a new array of integers which is good
             2. The way you attempted to fill the new array is incorrect
            */
            public int[] CreateRandomlyFilledArray(int size)
            {
                int[] newNums = new int[size];
                Random numGen = new Random(); //  This will be used to generate random numbers
                for (int elementNum = 0; elementNum < newNums.Length; elementNum++)
                {
                    // here we will put a random number in every position of the array using the random number generator
                    newNums[elementNum] = numGen.Next(0, 100); // we pass in you minimum and maximum into the next function and it will return a random number between them
                }
                // here we will return the array with the random numbers
                return newNums;
            }
            /*
            - This function prints out each item in an integer array
                1. You do not need to a return value as you will not be returning any thing so, Use "void".
            */
            public void Printarray(int[] value)
            {
                for (int i = 0; i < value.Length; i++)
                {
                    Console.WriteLine("value is: {0}", value[i]);
                }
            }
        }
    }
