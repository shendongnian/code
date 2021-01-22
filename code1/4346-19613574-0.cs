    public static string GenerateRandomCode(int length)
    {
        Random rdm = new Random();
        StringBuilder sb = new StringBuilder();
        
        for(int i = 0; i < length; i++)
            sb.Append(Convert.ToChar(rdm.Next(101,132)));
        return sb.ToString();
    }
