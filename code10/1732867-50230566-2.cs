    public static void bestEstimated(double[,] points)
    {
        var not20Points = new List<int>();
        for (int line = 0; line < 50; line++)
        {    
            bool is20 = false;
            for (int column = 0; column < 5; column++)
            {
                if (points[line, column] == 20)
                {
                    Console.WriteLine("20 points got: " + line + " competitor");
                    is20 = true;
                    break;
                }
            }
            if (is20 == false)
            {
                Console.WriteLine("competitor" + line + " didnt get 20 points"); //also can print it here if ya want...
                not20Points.Add(line);
            }
        }
        if (not20Points.Count == 50)
        {
            Console.WriteLine("No one got 20 points");
        }
        else
        {
            Console.WriteLine("Those lines did get 20 points: " + string.Join(",", Enumerable.Range(0, 50).Except(not20Points)));
            Console.WriteLine("Those lines didnt get 20 points: " + string.Join(",", not20Points));
        }
    }
