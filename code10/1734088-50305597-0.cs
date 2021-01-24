    bool firstError = true;
 
               while (line != null)
                {
                   int length = line.Length;
                   if (length > 2033)
                   {
                        if (firstError)
                        {
                            firstError = false; 
                            swe.WriteLine("Some records have been rejected at the pre validation phase.");
                            // etc. etc.
