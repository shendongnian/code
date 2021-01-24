    public static int displayQuestion(object whichQuestion)
    {
        string answer;
        int WorkPoints = 0;
        do
        {
            Console.WriteLine(whichQuestion);
            answer = Console.ReadLine();
            if (answer == "y")
            {
                WorkPoints++;
            }
        } while (answer != "y" && answer != "n");
        return WorkPoints;
        }
    }
