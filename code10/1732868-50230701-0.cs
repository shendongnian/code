    public static void bestEstimated(double[,] points)
        {
            bool is20 = false;
            for (int line = 0; line < 10; line++)
            {
                for (int column = 0; column < 5; column++)
                {
                    if (points[line, column] == 20)
                    {
                        Console.WriteLine("20 points got: " + line + " competitor");
                        is20 = true;
                        break;
                    }
					else
					{
						is20=false;
					}
                }
				if (!is20)
				{
					Console.WriteLine("20 points not got: " + line + " competitor");
				}
            }
            if(is20 == false)
            {
                Console.WriteLine("No one got 20 points: ");
            }
        }
