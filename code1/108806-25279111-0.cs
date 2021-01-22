        static void Main(string[] args)
        {
            int[] myArray = new int[] { 0, 1, 2, 3, 13, 8, 5,12,11,14 };
            int num1 = 0, temp = 0;
            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i] >= num1)
                {
                    temp = num1;
                    num1 = myArray[i];
                }
                else if ((myArray[i] < num1) && (myArray[i] > temp))
                {
                    temp = myArray[i];
                }
            }
            Console.WriteLine("The Largest Number is: " + num1);
            Console.WriteLine("The Second Highest Number is: " + temp);
            Console.ReadKey();
        }
