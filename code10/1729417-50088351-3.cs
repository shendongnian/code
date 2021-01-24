    string entry = "E#2";
    char[] output = new char[entry.Length];
    
    for(int i = 0, j =0; i < entry.Length ; i++)
    {
    	if(!Char.IsDigit(entry[i]))
        {
    		output[j] = entry[i];
            j++;
        }
    }
    
    Console.WriteLine(output);
