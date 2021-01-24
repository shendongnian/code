        static void Main(string[] args)
        {
            var CRInput = new Input(); //var supports almost all types of data, which simplifies the object declaration process
            Console.WriteLine(CRInput.EvalInput(Console.ReadLine()));
        }
    
        private class Input //Class names must start with capitals
        {
            public string InputString { get; set; }
    
            public string EvalInput(string input)
            {
                string result = string.Empty; //Initialize result with the value -> ""
    
                //The switch structure simplifies and shortens the repetitive use of else if
                switch (input)
                {
                    case "1": result = "1"; break; //if
                    case "2": result = "2"; break; //else if
                    case "3": result = "3"; break; //else if
                    default: result = "NOTHING"; break; //else
                }
    
                return result;
            }
        }
