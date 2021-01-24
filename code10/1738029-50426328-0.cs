            Console.WriteLine("Input the number of students: ");
            int numberOfStudents = int.Parse(Console.ReadLine());
            
            Student student = new Student();
            string studentId = "1";
            student.addGrade(double.Parse(studentId));
            double value;
            value = double.Parse(Console.ReadLine());
            student.addGrade(value);
            value = double.Parse(Console.ReadLine());
            student.addGrade(value);
            value = double.Parse(Console.ReadLine());
            student.addGrade(value);
            value = double.Parse(Console.ReadLine());
            student.addGrade(value);
            value = double.Parse(Console.ReadLine());
            student.addGrade(value);
            double avarageNumber = student.getAverage();
