    public int Sum(params int[] values)
    {
        int sum = 0;
        for(int i = 0; i < values.Length; i++){
            sum+=values[i];
        }
        return sum;
    }
    int answer2Parameters = Sum(1, 5);
    int answer3Parameters = Sum(1, 2, 3);
    int answer4Parameters = Sum(1, 3, 5, 6);
    
