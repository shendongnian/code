    public class MyViewModel {
    	: INotifyPropertyChanged
    	
    	public MyViewModel()
    	{
    		_myDataList = new List<Data>();
    	    for (int i = 0; i < 2; i++)
    		{
    			_myDataList.Add(new Data()
    			{
    				Id = i.ToString(),
    				BankName = "Bank al habib"+i,
    				NcsDate = "23/12/2018",
    				InstrumentNo = "234"+i,
    				Type = "Type abc"+i
    			});
    		}
    	}
    	
    	private List<Data> _myDataList;
    	public List<Data> MyDataList { 
            get { return _myDataList; }
            set
                {
                    _myDataList = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("MyDataList"));
                }
    	}
    	
        public event PropertyChangedEventHandler PropertyChanged;
    }
