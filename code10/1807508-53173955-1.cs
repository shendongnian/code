    public string PrintMatrix()
    {
        string result = string.Empty;
        for(int i = 0; i < lines ;i++)
        {
            for(int j = 0, j < cols; j++)
            {
                matrix[i,j] = rand.Next(1,10);
                result += $"{matrix[i,j]} ";
            }
            result +=  Environment.NewLine ;
        }
        return result;
    }
