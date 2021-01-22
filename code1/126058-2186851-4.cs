    int SumXValues(string filename)
    {
        string line;
        int sum = 0;
        int count = 0;
        using (var rdr = new StreamReader(filename))
        {
   
            while ( (line = rdr.ReadLine()) != null && count < 10)
            {
               int val;
               if (int.TryParse(line.Substring(3,3))
               {
                   if (val > 4 && val < 25)
                   {
                        sum += val;
                        count ++;
                   }
                }
            }
        }
        return sum;
    }
 
