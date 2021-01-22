            int a;
            Console.WriteLine("Enter size of Array:-");
            a = int.Parse(Console.ReadLine());
            int[] array = new int[a];
            Console.WriteLine("Enter the Elements of the Array:-");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("\nThe Elemets of the Array are:-");
            for (int j = 0; j < array.Length; j++)
            {
                Console.WriteLine(array[j]);
            }
