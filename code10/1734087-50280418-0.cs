    using (StreamReader sr = new StreamReader(inputFile))
            {
                using (StreamWriter sw = new StreamWriter(Dts.Connections["CE802CleanInput"].ConnectionString))
                {
                    using (StreamWriter swe = new StreamWriter(Dts.Connections["CE802PreValidationErrors"].ConnectionString));
                    {
                        swe.WriteLine("Some records have been rejected at the pre validation phase.");
                        swe.WriteLine("Those records will not be included in the process.");
                        swe.WriteLine("Please review the records below, fix and re submit if applicable.");
                        swe.WriteLine("Input file: " + Dts.Connections["CE802Input"].ConnectionString.ToString());
                        while (line = sr.ReadLine() != null)
                        {
                            int length = line.Length;
                            if (length > 2033)
                            {
                                swe.WriteLine();
                                swe.WriteLine(line);
                                count++;
                            }
                            else
                            {
                                sw.WriteLine(line);
                            }
                        }
                    }
                }
            }
