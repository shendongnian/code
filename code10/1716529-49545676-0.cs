    public int TotalWeight 
    {
         get
         {
             if(Weight == null || Product?.Weight == null)
                  return 0;
    
             return Weight * Product.Weight;
         }
    }
