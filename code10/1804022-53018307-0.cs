    public struct pay
    {
       public string name; 
       public int rate;  
       public int hours;    
       public decimal gross;    
       public decimal wtd;    
       public decimal ssd;    
       public decimal md;    
       public decimal net;
    
       public void Calculate()
       {
          gross = (rate * hours);
          wtd = (gross * (1 / (decimal)20));
          ssd = (gross * (3 / (decimal)100));
          md = (gross * (1 / (decimal)100));
          net = (gross - (md + ssd + wtd));
       }
    }
 
