            {
            using (var csv = new CsvReader(new StreamReader("PATH TO YOUR CSV FILE"), false))
                                                            
            {
                List<string> Lines = new List<string>();
                int counter = 0;
                while (csv.ReadNextRecord())
                {
                    if (counter == 0)
                    {
                        for (int i = 0; i < csv.FieldCount; i++)
                        {
                            Lines.Add(csv[i]);
                        }
                    }
                    else
                    {
                        Dictionary<string, string> testData = new Dictionary<string, string>();
                        for (int i = 0; i < Lines.Count; i++)
                        {
                            testData.Add(Lines[i], csv[i]);
                        }
                        yield return new TestCaseData(testData).SetName(csv[0].ToString());
                    }
                    counter++;
                }
            }
        }
