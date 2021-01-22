    public static string ByteConvert (int num)
    {
        int[] p = new int[8];
        string pa = "";
	    for (int ii = 0; ii<= 7;ii = ii +1)
	    {
		    p[7-ii] = num%2;
		    num = num/2;
	    }
	    for (int ii = 0;ii <= 7; ii = ii + 1)
	    {
		    pa += p[ii].ToString();
	    }
        return pa;
    }
