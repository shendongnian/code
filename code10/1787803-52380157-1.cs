    public class ObsCollection : ObservableCollection<Data>
    {
    	private Action SalaryChanged;
    	public ObsCollection(Action NotifyPropertyChanged)
    	{
    		SalaryChanged = NotifyPropertyChanged;
    	}
    
    	protected override void InsertItem(int index, Data item)
    	{
    		item.SalaryChanged = SalaryChanged;
    		base.InsertItem(index, item);
    	}
    }
