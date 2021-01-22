    public class State {
    	public int Value;
    }
    ...
    Dictionary<string, State> colStates = new Dictionary<string,State>();
    
    int OtherCount = 0;
    foreach(string key in colStates.Keys)
    {
        double  Percent = colStates[key].Value / TotalCount;
    
        if (Percent < 0.05)
        {
            OtherCount += colStates[key].Value;
            colStates[key].Value = 0;
        }
    }
    
    colStates.Add("Other", new State { Value =  OtherCount } );
