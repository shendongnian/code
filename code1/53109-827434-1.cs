    class Program
    {
        private static int Add(int number, int operand, int originalNumber, System.IO.StreamWriter logFile)
        {
            if (logFile != null)
                logFile.WriteLine("For {0}: Adding {1} to {2}", originalNumber, operand, number);
            return (number + operand);
        }
        private static int Subtract(int number, int operand, int originalNumber, System.IO.StreamWriter logFile)
        {
            if (logFile != null)
                logFile.WriteLine("For {0}: Subtracting {1} from {2}", originalNumber, operand, number);
            return (number - operand);
        }
        private static void Finish(int number, int originalNumber, System.IO.StreamWriter logFile)
        {
            Console.WriteLine("Program finished. {0} --> {1}", originalNumber, number);
            if (logFile != null)
            {
                logFile.WriteLine("Program finished. {0} --> {1}", originalNumber, number);
                logFile.Close();
                logFile = null;
            }
        }
        static void Main(string[] args)
        {
            int pNumber = 10;
            int pCurrentNumber = 10;
            System.IO.StreamWriter pLogFile;
            int qNumber = 25;
            int qCurrentNumber = 25;
            System.IO.StreamWriter qLogFile;
            pLogFile = new System.IO.StreamWriter("log-for-10.txt", true);
            pLogFile.WriteLine("Starting Program for {0}", pNumber);
            qLogFile = new System.IO.StreamWriter("log-for-25.txt", true);
            qLogFile.WriteLine("Starting Program for {0}", qNumber);
            pCurrentNumber = Program.Add(pCurrentNumber, 3, pNumber, pLogFile);
            pCurrentNumber = Program.Subtract(pCurrentNumber, 7, pNumber, pLogFile);
            qCurrentNumber = Program.Add(qCurrentNumber, 15, qNumber, qLogFile);
            qCurrentNumber = Program.Subtract(qCurrentNumber, 20, qNumber, qLogFile);
            qCurrentNumber = Program.Subtract(qCurrentNumber, 3, qNumber, qLogFile);
            Program.Finish(pCurrentNumber, pNumber, pLogFile);
            Program.Finish(qCurrentNumber, qNumber, qLogFile);
        }
    }
