    private List<SerialPort> _AllPorts;
	
    public ObservableCollection<SerialPort> PortsCollection
    {
        get 
		{ 
			if (CheckBoxChecked) 
			{
				return _AllPorts.where(x => x.IsOpen);
			}
			
			return _PortsCollection; 
		}
        set { _PortsCollection = value; OnPropertyChanged("PortsCollection"); }
    }
