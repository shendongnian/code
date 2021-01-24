    public static string ConvertToText(string NumberToConvert)
    {
      char[] getarray = NumberToConvert.ToCharArray();
        for (int getindex = 0; getindex < getarray.Length; getindex++)
        {
            char getchar = getarray[getindex];
            Console.WriteLine("getchar: " + getchar);
            //Console.WriteLine("getarray: " + getarray);
            Console.WriteLine("getindex: " + getindex);
            //int convertinput = Convert.ToInt32(getinput);
        }
        return ""; // return the Converted value
    }
