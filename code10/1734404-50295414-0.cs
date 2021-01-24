    public static int addTwoDigits(int n)
    {
        string number = n.ToString()
        char[] a = number.ToCharArray();
             
        int total = 0;
    
        for (int i = 0; i < a.Length; i++)
        {
            total +=  Convert.ToInt32(number[i].ToString());
        }
        return total;
    }
