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
                    int result=0;
                    if (Int32.TryParse(s, out result) )
                    {
                        if (s.Length != 4 || s.Length != 5)
                           writer2.WriteLine(line);
                    }
                }
            }
            File.Delete(newfilename);
            File.Move(tempfile, newfilename);
            File.Delete(tempfile);
