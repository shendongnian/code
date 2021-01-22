    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string InputFileName = @"input.txt";
                const string OutputFileName = @"output.txt";
    
                List<Line> parsedLineList = new List<Line>();
                
                using (StreamReader sr = new StreamReader(InputFileName))
                {
                    string inputLine;
                    int lineNum = 0;
    
                    while ((inputLine = sr.ReadLine()) != null)
                    {
                        lineNum++;
    
                        Line parsedLine = new Line(inputLine);
    
                        if (parsedLine.IsMatch)
                        {
                            parsedLineList.Add(parsedLine);
                        }
                        else
                        {
                            Debug.WriteLine("Line {0} did not match pattern {1}", lineNum, inputLine);
                        }
                    }
                }
    
                using (StreamWriter sw = new StreamWriter(OutputFileName))
                {
                    foreach (Line line in parsedLineList)
                    {
                        sw.WriteLine(line.ToString());
                    }
                }
            }
        }
    }
