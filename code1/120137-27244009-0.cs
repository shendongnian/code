    //Below is the test string 
    string test = "YK     002       10        23           30         5       TDP_XYZ  "
    private static string return_with_comma(string line)
        {
            line = line.TrimEnd();
            line = line.Replace("  ", ",");
            line = Regex.Replace(line, ",,+", ",");
            string[] array;
            array = line.Split(',');
            for (int x = 0; x < array.Length; x++)
            {
                line += array[x].Trim();
            }
            line += "\r\n";
            return line;
        }
     string result = return_with_comma(test);
     //Output is
     //YK,002,10,23,30,5,TDP_XYZ  
