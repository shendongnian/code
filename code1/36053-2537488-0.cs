    using System;
    using System.IO;
    using QuickPDFDLL0718;
    
    namespace QPLConsoleApp
    {
        public class QPL
        {
            public static void Main()
            {
                // This example uses the DLL edition of Quick PDF Library
                // Create an instance of the class and give it the path to the DLL
                PDFLibrary QP = new PDFLibrary("QuickPDFDLL0718.dll");
    
                // Check if the DLL was loaded successfully
                if (QP.LibraryLoaded())
                {
                    // Insert license key here / Check the license key
                    if (QP.UnlockKey("...") == 1)
                    {
                        QP.LoadFromFile(@"C:\Program Files\Quick PDF Library\DLL\GettingStarted.pdf");
    
                        int iPageCount = QP.PageCount();
                        int PageNumber = 1;
                        int MatchesFound = 0;
    
                        while (PageNumber <= iPageCount)
                        {
                            QP.SelectPage(PageNumber);
                            string PageText = QP.GetPageText(3);
    
                            using (StreamWriter TempFile = new StreamWriter(QP.GetTempPath() + "temp" + PageNumber + ".txt"))
                            {
                                TempFile.Write(PageText);
                            }
    
                            string[] lines = File.ReadAllLines(QP.GetTempPath() + "temp" + PageNumber + ".txt");
                            string[][] grid = new string[lines.Length][];
    
                            for (int i = 0; i < lines.Length; i++)
                            {
                                grid[i] = lines[i].Split(',');
                            }
    
                            foreach (string[] line in grid)
                            {
                                string FindMatch = line[11];
    
                                // Update this string to the word that you're searching for.
                                // It can be one or more words (i.e. "sunday" or "last sunday".
    
                                if (FindMatch.Contains("characters"))
                                {
                                    Console.WriteLine("Success! Word match found on page: " + PageNumber);
                                    MatchesFound++;
                                }
                            }
                            PageNumber++;
                        }
    
                        if (MatchesFound == 0)
                        {
                            Console.WriteLine("Sorry! No matches found.");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Total: " + MatchesFound + " matches found!");
                        }
                        Console.ReadLine();
                    }
                }
            }
        }
    }
