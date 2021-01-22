    public class Program
    {
        public static void Main(string [] args)
        {
            Teacher JohnSmith = new Teacher("John Smith");
    
            Student Jim = new Student("Jim",100,JohnSmith);
            Student Sue = new Student("Sue",90,JohnSmith);
            Student Sally = new Student("Sally",70,JohnSmith);
            Student Robert = new Student("Robert",100,JohnSmith);
            //add our resident overachiever
            Student JonSkeet = new Student("Jon Skeet",150,JohnSmith);
    
            JohnSmith.ComputeAverageGrade();
    
            Console.WriteLine("Course Average for " + JohnSmith.Name + " is " +
                JohnSmith.CourseAverage.ToString());
        }
    }
