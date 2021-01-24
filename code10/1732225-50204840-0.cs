    static void ParseLineIn(string lineIn, uint i)
    {
        string[] words = new string[5];
        lineIn = lineIn.Trim();
        while (Regex.IsMatch(lineIn, "[ ]{2}"))
            lineIn = lineIn.Replace("  ", " ");
        words = lineIn.Split(' ');
        lastNameArray[i] = words[0];
        // i = 0;
        // No loop needed, you are reading one line of data and setting 
        // the appropriate index in the arrays
        // while (i <= numOfEmployees)
        //{
            lastNameArray[i] = words[0];
            firstNameArray[i] = words[1];
            deptArray[i] = uint.Parse(words[2]);
            rateArray[i] = double.Parse(words[3]);
            hoursArray[i] = double.Parse(words[4]);
        //    i++;
        //}
    }
