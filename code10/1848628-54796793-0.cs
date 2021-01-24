        private static void Main(string[] args)
        {
            ProgramLoop();
        }
        private static void ProgramLoop()
        {
            var grades = new List<double>();
            double average;
            var exit = false;
            do
            {
                System.Console.WriteLine("1. Enter Grades");
                System.Console.WriteLine("2. Get Average");
                System.Console.WriteLine("3. My program");
                System.Console.WriteLine("4. exit");
                var input = System.Console.ReadLine();
                System.Console.WriteLine("");
                switch (input)
                {
                    case "1":
                        grades = EnterGrades();
                        break;
                    case "2":
                        average = GetAverage(grades);
                        break;
                    case "3":
                        MyProgram();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        System.Console.WriteLine($"'{input}' is not a valid choice.");
                        break;
                }
            }
            while (exit == false);
        }
        private static List<double> EnterGrades()
        {
            int numberOfGrades = 0;
            var grades = new List<double>();
            
            System.Console.WriteLine("How many grades do you want to enter? ");
            // Read number of grades
            while (!int.TryParse(System.Console.ReadLine(), out numberOfGrades) || numberOfGrades < 1)
            {
                System.Console.WriteLine("Please enter a valid number");
            }
            while (grades.Count != numberOfGrades)
            {
                // Read grade
                System.Console.WriteLine("Enter Grade: ");
                double grade;
                while (!double.TryParse(System.Console.ReadLine(), out grade) || grade < 0 || grade > 100)
                {
                    System.Console.WriteLine("Please enter a valid grade between 0.0 and 100.0");
                }
                grades.Add(grade);
            }
            return grades;
        }
        private static double GetAverage(IList<double> grades)
        {
            var average = grades.Average();
            if (average >= 90)
            {
                System.Console.WriteLine($"The average is {average}, which is an A.");
            }
            else if (average >= 80)
            {
                System.Console.WriteLine($"The average is {average}, which is an B.");
            }
            else if (average >= 70)
            {
                System.Console.WriteLine($"The average is {average}, which is an C.");
            }
            else if (average >= 60)
            {
                System.Console.WriteLine($"The average is {average}, which is an D.");
            }
            else
            {
                System.Console.WriteLine($"The average is {average}, which is an E.");
            }
            return average;
        }
