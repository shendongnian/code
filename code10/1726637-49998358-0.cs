                for (int i = 0; i < lottonumbers.Length; i++)
            {
                Console.WriteLine("You must enter 10 bingo numbers.Only numbers between 1 - 25 are valid!");
                int element = 0;
                if (int.TryParse(Console.ReadLine(), out element))
                {
                	if (element >= 1 && element <= 25) 
                    {
						lottonumbers[i] = element;
                    }
                    else 
                    {
                    	Console.WriteLine("Endast siffror siffror mellan 1 och 25 är tillåtna, mata igen");
						--i;
                    }
                }
                else
                {
                    Console.WriteLine("No letters are valid, only numbers(integers).");
                    --i;
                }
            }
