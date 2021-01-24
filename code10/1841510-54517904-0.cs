Program p = new Program();
string name = Console.ReadLine();
int gradesPassed = 12;
int currentGrade = 0;
double totalSumOfGrades = 0;
while (currentGrade <= gradesPassed)
{
    double finalGrade = double.Parse(Console.ReadLine());
    gradeFunction(finalGrade, ref totalSumOfGrades, ref currentGrade);
}
public static void gradeFunction(double finalGrade, ref double totalSumOfGrades, ref int currentGrade)
        {
            if (finalGrade >= 4.00)
            {
                totalSumOfGrades += finalGrade;
                currentGrade++;
            }
        }
