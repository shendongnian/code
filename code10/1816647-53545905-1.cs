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
                    System.Text.RegularExpressions.Regex newRecordSartRegex = new System.Text.RegularExpressions.Regex("^\\d{4}-\\d{2}-\\d{2},");
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        if (headerline)
                        {
                            //this handles the header record
                            records.Add(currentLine);
                            headerline = false;
                        }
                        else if (newRecordSartRegex.IsMatch(currentLine))
                        {
                            //this is a new record, so create a new entry in the list
                            records.Add(currentLine);
                        }
                        else
                        {
                            //this is the continuation on a ongoing record,
                            //so append to the last item in the list
                            if (!string.IsNullOrWhiteSpace(currentLine))
                            {
                                //add to the current record only if the line is not empty
                                records[records.Count - 1] += currentLine;
                            }
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
