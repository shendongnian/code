            double[] array = new double[6];
            Console.WriteLine("Please Sir Enter 6 Floating numbers");
            for (int i = 0; i < 6; i++)
            {
                array[i] = Convert.ToDouble(Console.ReadLine());
            }
            double sum = 0;
            foreach (double d in array)
            {
                sum += d;
            }
            double average = sum / 6;
            Console.WriteLine("===============================================");
            Console.WriteLine("The Values you've entered are");
            Console.WriteLine("{0}{1,8}", "index", "value");
            for (int counter = 0; counter < 6; counter++)
                Console.WriteLine("{0,5}{1,8}", counter, array[counter]);
            Console.WriteLine("===============================================");
            Console.WriteLine("The average is ;");
            Console.WriteLine(average);
            Console.WriteLine("===============================================");
            Console.WriteLine("would you like to search for a certain elemnt ? (enter yes or no)");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "yes":
                    Console.WriteLine("===============================================");
                    Console.WriteLine("please enter the array index you wish to get the value of it");
                    int index = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("===============================================");
                    Console.WriteLine("The Value of the selected index is:");
                    Console.WriteLine(array[index]);
                    break;
                case "no":
                    Console.WriteLine("===============================================");
                    Console.WriteLine("HAVE A NICE DAY SIR");
                    break;
            }
        }
    }
}
