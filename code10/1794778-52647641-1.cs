    public class MyViewModel : INotifyPropertyChanged
    {
    	public int NumberOfIndividualEngagements 
    	{
    		get => _numberOfIndividualEngagements;
    		set
    		{
    			_numberOfIndividualEngagements = value;
    			OnPropertyChanged(nameof(NumberOfIndividualEngagements));
    			OnPropertyChanged(nameof(TotalAudienceReached));
    		}
    	}
    	public int NumberOfGroupEngagements 
    	{
    		get => _numberOfGroupEngagements;
    		set
    		{
    			_numberOfGroupEngagements = value;
    			OnPropertyChanged(nameof(NumberOfGroupEngagements));
    			OnPropertyChanged(nameof(TotalAudienceReached));
    		}
    	}
    
    	public int TotalAudienceReached => 
    		NumberOfIndividualEngagements + NumberOfGroupEngagements != 0 
    				? NumberOfIndividualEngagements + NumberOfGroupEngagements 
    				: 0;
    }
