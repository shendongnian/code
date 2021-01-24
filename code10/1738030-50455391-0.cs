    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the number of students: ");
            int n = int.Parse(Console.ReadLine()); 
            // Create array of size n (instead of 6)
            // Array is created but individual Students are not created yet!
            Student[] students = new Student[n];
            // Use a loop to get all student info
            for (int s = 0; s < n; s++) {
                string studentId = $"Student{s+1}";
                // Important! Need to create a student object
                students[s] = new Student(studentId);
                // Use another loop to get grades
                for (int g = 0; g < 5; g++) {
                    double grade = double.Parse(Console.ReadLine());
                    students[s].addGrade(grade);
                }
                // Print average
                Console.WriteLine($"{students[s].id} average = {students[s].getAverage()}");
            }
        }
