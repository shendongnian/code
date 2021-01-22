    private IDictionary<Strink, Int32> NextFreeActionNumbers = null;       
    private void InitializeNextFreeActionNumbers()
    {
       this.NextFreeActionNumbers = new Dictionary<String, Int32>();
       this.NextFreeActionNumbers.Add("Blur", 1);
       this.NextFreeActionNumbers.Add("Sharpen", 1);
       this.NextFreeActionNumbers.Add("Contrast", 1);
       // ... and so on ...
    }
    
    private String GetNextActionName(String action)
    {
       Int32 number = this.NextFreeActionNumbers[action];
    
       this.NextFreeActionNumbers[action] = number + 1;
    
       return String.Format("{0} {1}", action, number);
    }
