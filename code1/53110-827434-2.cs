    // Another instance-based approach
    class ProgramLogic
    {
        private System.IO.StreamWriter _logStream;
        private int _originalNumber;
        private int _currentNumber;
        public ProgramLogic(int number, string logFilePath)
        {
            _originalNumber = number;
            _currentNumber = number;
            try
            {                
                _logStream = new System.IO.StreamWriter(logFilePath, true);
                _logStream.WriteLine("Starting Program for {0}", _originalNumber);
            }
            catch
            {
                _logStream = null;
            }
        }
        public void Add(int operand)
        {
            if (_logStream != null)
                _logStream.WriteLine("For {0}: Adding {1} to {2}", _originalNumber, operand, _currentNumber);
            _currentNumber += operand;
        }
        public void Subtract(int operand)
        {
            if (_logStream != null)
                _logStream.WriteLine("For {0}: Subtracting {1} from {2}", _originalNumber, operand, _currentNumber);
            _currentNumber -= operand;            
        }
        public void Finish()
        {            
            Console.WriteLine("Program finished. {0} --> {1}", _originalNumber, _currentNumber);
            if (_logStream != null)
            {
                _logStream.WriteLine("Program finished. {0} --> {1}", _originalNumber, _currentNumber);
                _logStream.Close();
                _logStream = null;
            }
        }        
    }
    class Program
    {        
        static void Main(string[] args)
        {
            ProgramLogic p = new ProgramLogic(10, "log-for-10.txt");
            ProgramLogic q = new ProgramLogic(25, "log-for-25.txt");
            p.Add(3);         // p._number = p._number + 3;
            p.Subtract(7);    // p._number = p._number - 7;
            q.Add(15);        // q._number = q._number + 15;
            q.Subtract(20);   // q._number = q._number - 20;
            q.Subtract(3);    // q._number = q._number - 3;
            p.Finish();
            q.Finish();     
        }
    }
