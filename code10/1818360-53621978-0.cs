        static void Main(string[] args)
        {
            StreamWriter outputFile;
            FileStream fsOutput = new FileStream("outFile.bin", FileMode.Create);
            BinaryWriter myOutputFile = new BinaryWriter(fsOutput);
            outputFile = new StreamWriter("ex1.txt");
            outputFile = new StreamWriter("ex1.bin");
            int studentAmount;      // This should be an int not double
            string studentName;
            int studentHeight;
            double studentWeight;
            Console.Write("Data of how many students do you want to enter? ");
            // You should validate the input using the appropriate TryParse
            var input = Console.ReadLine();
            if (!int.TryParse(input, out studentAmount))
            {
                // You need to append 'Console.' to the beginning of the read/write operations
                Console.WriteLine("You entered an invalid number for  student amounnt - ending...");
                Console.ReadKey();
                return;
            }
            // double x = 0;    // You don't need this variable
            do
            {
                Console.Write("Enter the name of the student: ");
                studentName = Console.ReadLine();
                myOutputFile.Write(studentName);
                outputFile.WriteLine(studentName);
                Console.Write("Enter the height of the student in centimeters: ");
                input = Console.ReadLine();
                if (!int.TryParse(input, out studentHeight))
                {
                    Console.WriteLine("You entered an invalid number for  height - ending...");
                    Console.ReadKey();
                    return; 
                }
                outputFile.WriteLine(studentHeight);
                myOutputFile.Write(studentHeight);
                Console.Write("Enter the weight of the student in kilograms: ");
                input = Console.ReadLine();
                if (!double.TryParse(input, out studentWeight))
                {
                    Console.WriteLine("You entered an invalid number for weight - ending...");
                    Console.ReadKey();
                }
                outputFile.WriteLine(studentWeight);
                myOutputFile.Write(studentWeight);
                // You need to decrement your counter so you don't loop forever
            } while (--studentAmount > 0);
            outputFile.Close();
            Console.ReadKey();
        }
