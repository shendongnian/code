    private static void Main()
    {
        int numStudents = GetIntFromUser("Enter the number of students: ");
        int[] scores = new int[numStudents];
        string[] names = new string[numStudents];
        for (int i = 0; i < numStudents; i++)
        {
            Console.WriteLine("\nStudent #" + (i + 1));
            Console.Write(" - Enter student's name: ");
            names[i] = Console.ReadLine();
            scores[i] = GetIntFromUser(" - Enter student's score: ");
        }
        Console.WriteLine("\nHere are the students who scored less than 40:");
        for (int i = 0; i < numStudents; i++)
        {
            if (scores[i] < 40)
            {
                Console.WriteLine(" - " + names[i] + " scored " + scores[i]);
            }
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
