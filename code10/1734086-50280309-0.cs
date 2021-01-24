    //Pass the file path and file name to the StreamReader and StreamWriter constructors
                StreamReader sr = new StreamReader(inputFile);
                StreamWriter sw = new StreamWriter(Dts.Connections["CE802CleanInput"].ConnectionString);
                StreamWriter swe = new StreamWriter(Dts.Connections["CE802PreValidationErrors"].ConnectionString);
    
                bool writeHeaderLine = false;
    
                //Read the first line
                line = sr.ReadLine();
    
                while (line != null)
                {
                    int length = line.Length;
                    if (length > 2033)
                    {
                        // only do this if it is false/first time
                        if(writeHeaderLine == false) // THIS IS WHERE I WOULD HAVE TO ADD THE CONDITION
                        {
                            swe.WriteLine("Some records have been rejected at the pre validation phase.");
                            swe.WriteLine("Those records will not be included in the process.");
                            swe.WriteLine("Please review the records below, fix and re submit if applicable.");
                            swe.WriteLine("Input file: " + Dts.Connections["CE802Input"].ConnectionString.ToString());
                            swe.WriteLine();                        
                            writeHeaderLine = true;
                        }
                        
                        // always do this
                        swe.WriteLine(line);
                        count++;
                        
                    }
                    if (length <= 2033)
                    {
                        sw.WriteLine(line);
                    }
                    line = sr.ReadLine();
                }
