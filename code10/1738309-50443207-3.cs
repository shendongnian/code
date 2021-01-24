                ...
                Student[] students = new Student[n];
                var distribution = new int[11];
                ...
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine($"Enter grade {j + 1} for student {i + 1}: ");
                    double grade = double.Parse(Console.ReadLine());
                    students[i].addGrade(grade);
                    // assuming grade value won't be greater than 100 or less than 0
                    distributions[(int)grade / 10]++;
                }
                ...
                ...
