    public static void ValueFast(this ProgressBar progressBar, int value)
    {
        if (value < 100)    // prevent ArgumentException error on value = 100
        {
            progressBar.Value = value + 1;    // set the value +1
        }
    
        progressBar.Value = value;    // set the actual value
    
    }
