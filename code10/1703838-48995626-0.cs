    public static string[] ColorToBinary(Color color)
    {
        string[] binary = new strin[3];
    
        binary[0] = ByteToBinary(color.R);
        binary[1] = ByteToBinary(color.G);
        binary[2] = ByteToBinary(color.B);
    
        return binary;
    }
    
    
    private static string ByteToBinary(byte b)
    {
    	return Convert.ToString(b, 2).PadLeft(8, '0');
    }
