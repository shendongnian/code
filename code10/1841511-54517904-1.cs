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
I have added the ref keywords for `currentGrade` and `totalSumOfGrades` on both the call and the declaration so that the variables are updated properly which I believe is the most impact-free way to get the code working.
