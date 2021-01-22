    class Program
    {
        static void Main(string[] args)
        {
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(x);
            {
                
   
                int[] dynamicArray1 = { };//empty array
                int[] numbers;//another way to declare a variable array as all arrays start as variable size
                numbers = new int[x];//setting this array to an unknown variable (will be user input)
                for (int tmpInt = 0; tmpInt < x; tmpInt++)//build up the first variable array (numbers)
                {
                    numbers[tmpInt] = tmpInt;
                }
                Array.Resize(ref numbers,y);// resize to variable input
                dynamicArray1 = numbers;//set the empty set array to the numbers array size 
                for (int z = 0; z < y; z++)//print to the new resize
                {
                    Console.WriteLine(numbers[z].ToString());//print the numbers value
                    Console.WriteLine(dynamicArray1[z].ToString());//print the empty set value
                }
            }
            Console.Write("Dynamic Arrays  ");
            var name = Console.ReadLine();
        }
    }
