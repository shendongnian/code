    string Process(string stringOutput)
            {
                foreach (string c in carMake)
                {
                    int i = stringOutput.IndexOf(c.ToLower());
                    if (i > -1)
                    {
                        stringOutput=stringOutput.Replace(c.ToLower(), c);
                    }
                }
                return stringOutput;
            }
