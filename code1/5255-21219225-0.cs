        public Dictionary<string, string> nameOfAlreadyAcessed = new Dictionary<string, string>();
        public string nameOf(object obj, int level = 1)
        {
            StackFrame stackFrame = new StackTrace(true).GetFrame(level);
            string fileName = stackFrame.GetFileName();
            int lineNumber = stackFrame.GetFileLineNumber();
            string uniqueId = fileName + lineNumber;
            if (nameOfAlreadyAcessed.ContainsKey(uniqueId))
                return nameOfAlreadyAcessed[uniqueId];
            else
            {
                System.IO.StreamReader file = new System.IO.StreamReader(fileName);
                for (int i = 0; i < lineNumber - 1; i++)
                    file.ReadLine();
                string varName = file.ReadLine().Split(new char[] { '(', ')' })[1];
                nameOfAlreadyAcessed.Add(uniqueId, varName);
                return varName;
            }
        }
