    using System;
    using System.Collections.Generic;
    
    namespace _53543524_FileWithBrokenRecords
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> records = new List<string>();
                using (System.IO.StreamReader sr = new System.IO.StreamReader("M:\\StackOverflowQuestionsAndAnswers\\53543524_FileWithBrokenRecords\\sampledata.txt"))
                {
                    string currentLine = string.Empty;
                    bool headerline = true;
                    System.Text.RegularExpressions.Regex regx = new System.Text.RegularExpressions.Regex("^\\d{4}-\\d{2}-\\d{2},");
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        if (headerline)
                        {
                            records.Add(currentLine);
                            headerline = false;
                        }
                        else if (regx.IsMatch(currentLine))
                        {
                            records.Add(currentLine);
                        }
                        else
                        {
                            records[records.Count - 1] = $"{records[records.Count - 1]} {currentLine}";
                        }
                    }
                }
    
                foreach (string item in records)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }
        }
    }
