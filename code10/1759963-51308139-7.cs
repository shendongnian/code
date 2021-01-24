    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace _51306985
    {
        class Program
        {
            static List<List<string>> listOfList = new List<List<string>>();
            static int longestCol = 0;
            static void Main(string[] args)
            {
                FillTheList("M:\\StackOverflowQuestionsAndAnswers\\51306985\\testdata.csv");
                PadTheList();
                SpitItBackOut();
                SpitItOutToAFile("M:\\StackOverflowQuestionsAndAnswers\\51306985\\testdata.csv");
                Console.ReadLine();
            }
    
            private static void SpitItOutToAFile(string v)
            {
                string newPath = $"{System.IO.Path.GetDirectoryName(v)}\\{System.IO.Path.GetFileNameWithoutExtension(v)}_Rotated{System.IO.Path.GetExtension(v)}";
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(newPath))
                {
                    for (int i = 0; i < longestCol; i++)
                    {
                        string lineToWrite = string.Empty;
                        for (int b = 0; b < listOfList.Count; b++)
                        {
                            lineToWrite += $"{listOfList[b][i]},";
                        }
                        lineToWrite = lineToWrite.Substring(0, lineToWrite.Length - 1);//remove the hanging comma
                        if (lineToWrite != "")
                        {
                            sw.WriteLine(lineToWrite);
                        }
    
                    }
                }
            }
    
            private static void SpitItBackOut()
            {
                for (int i = 0; i < longestCol; i++)
                {
                    string lineToWrite = string.Empty;
                    for (int b = 0; b < listOfList.Count; b++)
                    {
                        lineToWrite += $"{listOfList[b][i]},";
                    }
                    lineToWrite = lineToWrite.Substring(0, lineToWrite.Length - 1);//remove the hanging comma
                    if (lineToWrite != "")
                    {
                        Console.WriteLine(lineToWrite);
                    }
                    
                }
            }
    
            private static void PadTheList()
            {
                foreach (List<string> item in listOfList)
                {
                    while (item.Count < longestCol)
                    {
                        item.Add("");
                    }
                }
            }
    
            private static void FillTheList(string v)
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(v))
                {
                    string currentLine = string.Empty;
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        listOfList.Add(currentLine.Split(',').ToList());
                        if (listOfList.Last().Count > longestCol)
                        {
                            longestCol = listOfList.Last().Count;
                        }
                    }
                }
            }
        }
    }
