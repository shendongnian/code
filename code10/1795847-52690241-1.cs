    void Main()
    {
    	var data = new []
    	{
    		new Data { IsFirstLogin = true , OnlineTime =   0, Bound = 0  }, // bound + 5
    		new Data { IsFirstLogin = true , OnlineTime = 101, Bound = 0  }, // bound + 15
    		new Data { IsFirstLogin = false, OnlineTime =  50, Bound = 10 }, // bound + 0
    		new Data { IsFirstLogin = false, OnlineTime = 200, Bound = 25 }, // bound + 10
    	};
    	
    	var query = data
    		.Select(x =>
    			{
    				x.Bound += 
    					x.IsFirstLogin && x.OnlineTime > 100 ? 15 :
    					x.IsFirstLogin ? 5 :
    					x.OnlineTime > 100 ? 10 : 0;
    				return x;
    			}
    		)
    		.Dump() // remove this line if not in LinqPad
    	;
    }
    
    public class Data
    {
    	public bool IsFirstLogin { get; set; }
    	public int OnlineTime { get; set; }
    	public int Bound { get; set; }
    }
