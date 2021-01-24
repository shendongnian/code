    static void LottoMethod(int[] randNums,int[] userNums)
        {
            Console.WriteLine("Guess 10 numbers");
            for(int i = 0; i <= userNums.Length-1; i++)
            {
                userNums[i] = Int32.Parse( Console.ReadLine());
            }
            Console.WriteLine("The numbers you entered: ");
            foreach(int k in userNums)
            {
                Console.Write(k+"   ");
            }
            //generate 10 numbers randomly
            Random rnds = new Random();
            for(int k = 0; k <= randNums.Length - 1; k++)
            {
                randNums[k] = rnds.Next(1, 26);
            }
            Console.WriteLine("Random Numbers");
            foreach(int i in randNums)
            {
                Console.Write(i + "   ");
            }
            int correctNums = 0;
            //Check if random numbers correspond with entered numbers
            try
            {
                for(int i = 0; i <= randNums.Length-1; i++)
                {
                    for(int j = 0; j <= userNums.Length-1; j++)
                    {
                        if (randNums[i] == userNums[j])
                        {
                            correctNums++;
                        }
                    }
                }
                Console.WriteLine($"There are {correctNums} numbers ");
            }
            catch(Exception e) {
                throw new Exception(e.ToString());
            }
        }
