    public string LogicFullName(string fName)
        {
            string logicName = String.Empty;
            string[] splitFullName = fName.Trim().Split(' ');
            for (int i = 0; i < splitFullName.Length; i++)
            {
                if (logicName == String.Empty && i == 0)
                {
                    logicName = splitFullName[i].Trim();
                }
                else
                {
                    if (splitFullName[i] != String.Empty)
                        logicName = logicName + " " + splitFullName[i].Trim();
                }
            }
            return logicName;
         }
