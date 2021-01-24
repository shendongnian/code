bool exit = false;
// added variables outside of loop so they are available everywhere in the method
double grades = 0;
int gradesCount = 0;
do
{
    Console.WriteLine("1. Enter Grades");
    Console.WriteLine("2. Get Average");
    Console.WriteLine("3. exit");
    string input = Console.ReadLine();
    Console.WriteLine("");
    if (input == "1")
    {
        int totalGrades = 0;
        //User Input
        Console.WriteLine("How many grades do you want to enter? ");
                    
        //While loop for TryParse
        while (!int.TryParse(Console.ReadLine(), out totalGrades))
        {
            Console.WriteLine("Please enter a valid number");
        }
        // increment the count of grades by the number of grades the user wants to add
        gradesCount += totalGrades;
        // variable to keep a count and avoid infinite loop
        int addedGradesCount = 0;
        // while loop works like a for loop using our variable to keep count of grades we add
        while (addedGradesCount < totalGrades)
        {
            Console.WriteLine("Enter Grade: ");
            // variable to store entered grade
            double newGrade = 0;
            //Reusing code from while loop above for TryParse
            while (!double.TryParse(Console.ReadLine(), out newGrade))
            {
                Console.WriteLine("Please enter a valid number");
            }
            // increment running total of grades with the user input number
            grades += newGrade;
            // output to user - got rid of loop through totalGrades
            Console.WriteLine("You entered: " + newGrade + " - Total: " + grades);
            // increment variable to keep count! if this is not here, you will have infinite loop
            addedGradesCount++;
        }
        // Console.ReadLine(); // not needed
    }
    else if (input == "2")
    {
        // calculate average using the method variables we initialized at the beginning
        double average = (grades / gradesCount);
        if (average >= 90)
        {
            Console.WriteLine($"The average is a {average} which is an A.");
        }
        else if (average >= 80)
        {
            Console.WriteLine($"The average is a {average} which is an B.");
        }
        else if (average >= 70)
        {
            Console.WriteLine($"The average is a {average} which is an C.");
        }
        else if (average >= 60)
        {
            Console.WriteLine($"The average is a {average} which is an D.");
        }
        else
        {
            Console.WriteLine($"The average is a {average} which is an E.");
        }
    }
    else
    {
        exit = true;
    }
} while (exit == false);
Console.ReadKey();
