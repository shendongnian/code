    private string[] FindConversionSetting(string[] input, StreamReader reader) 
    {        
        do 
        {
            string line = reader.ReadLine();
            if (line != null) 
            {
                string[] settings = line.Split(',');
                bool sourcesMatch = string.Compare(input[1], settings[0], true) == 0;
                bool targetsMatch = string.Compare(input[2], settings[1], true) == 0;
                
                if (sourcesMatch && targetsMatch) 
                {                    
                    return settings; // Match found
                }
            }
        } while (line != null);
        
        return null; // No match
    }
