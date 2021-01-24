            double x = studentAmount;  //this line
            do
            {
                Write("Enter the name of the student: ");
                studentName = ReadLine();
                myOutputFile.Write(studentName);
                outputFile.WriteLine(studentName);
                Write("Enter the height of the student in centimeters: ");
                studentHeight = int.Parse(ReadLine());
                outputFile.WriteLine(studentHeight);
                myOutputFile.Write(studentHeight);
                Write("Enter the weight of the student in kilograms: ");
                studentWeight = double.Parse(ReadLine());
                outputFile.WriteLine(studentWeight);
                myOutputFile.Write(studentWeight);
                x = x - 1; //add this line
            } while (x > 0);  //this line
