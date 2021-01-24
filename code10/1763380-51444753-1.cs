    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number(s): ");
            double[] values = new double[3]; //initialize double array with its size
            
            for (int i = 0; i < values.Length; i++)
            {
                //iterate through the array and assign value to each index of it.
                values[i]=Convert.ToDouble(Console.ReadLine());
            }
            average(values);
            Console.ReadKey();
        }
        //set method that accepts double array as parameter
        static void average(double[] values)
        {
            double average =0;// declare var that will hold the sum of numbers 
            int length = values.Length;//get array length, use it to divide the summation of numbers
            Console.WriteLine("You have entered: ");
            for (int i = 0; i < values.Length; i++)
            {
                //also display the numbers if you need to
                Console.WriteLine(values[i]);
                //iterate through each value in the array and sum it up.
                average = values[i] + average;
            }
            //divide the sum of numbers by the length of array
            Console.WriteLine("The average is: " + (average/length));
        }
    }
