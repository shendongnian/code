            //Delete the last line from the file.  This line could be 8174, 10000, or anything.  This is from SO 
            string tempfile = @"C:\junk_temp.txt"; 
 
            using (StreamReader reader2 = new StreamReader(newfilename)) 
            { 
                using (StreamWriter writer2 = new StreamWriter(tempfile)) 
                { 
                    string line = reader2.ReadLine(); 
 
                    while (!reader2.EndOfStream) 
                    { 
                        writer2.WriteLine(line); 
                        line = reader2.ReadLine(); 
                    } // by reading ahead, will not write last line to file  
                    
                    // If the last line read does not match your condition
                    // we write it to the new file
                    if (!Regex.IsMatch(line, @"^\d{4,5}"))
                    {
                        writer2.WriteLine(line); 
                    } 
                } 
            } 
 
            File.Delete(newfilename); 
            File.Move(tempfile, newfilename); 
            File.Delete(tempfile);
