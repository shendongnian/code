    partial class Principal
    {
    	public decimal Capacity
    	{
    		get
    		{
    			return this.Scale == 0 ? 0 : this.Visits.Select(v => 
    				(v.Frequency.Value == 1 ? 1 : v.Frequency.Value * 1.8) / this.Scale).Sum();
    		}
    	}	
    }
