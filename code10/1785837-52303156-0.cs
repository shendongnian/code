            int count = 0;
            List<int> numeros = new List<int>();
            Console.Write("How many numbers?: ");
            int.TryParse(Console.ReadLine(), out count);
            for(int i = 1; i < count + 1; i++)
            {
                Console.Write("Numero {0}: ", i);
                numeros.Add(Convert.ToInt32(Console.ReadLine()));
            }
            int sum = 0;
            foreach(var i in numeros)
            {
                sum += i;
            }
            int average = sum / numeros.Count;
            Console.WriteLine(average);
