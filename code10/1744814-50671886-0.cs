    bool found = false;
    using (StreamReader sr = new StreamReader("TestFile.txt")) 
    {
        string line;
        // Read and display lines from the file until the end of 
        // the file is reached.
        while ((line = sr.ReadLine()) != null) 
        {
            // bypass the search once we've found a match
            if(found || line.Contains(searchString))
            {
                // Do some logic (the search string is found)
                //   I need to show 3 lines here
                //    Code:1
                //   Note name: Josh
                //   Body Note : tex
                // for the moment Console.WriteLine(line);just shows me 1               
                found = true;
                Console.WriteLine(line);
                count++;
                if(count == 3) {
                    break;
                }
            }
        }
    }
