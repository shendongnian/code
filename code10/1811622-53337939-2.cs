    private List<SerialPort> _AllPorts;
	
    public ObservableCollection<SerialPort> PortsCollection
    {
        get 
		{ 
			return new ObservableCollection<SerialPort>(_AllPorts.Where(x => x.IsOpen == CheckBoxChecked));
		}
        set { _PortsCollection = value; OnPropertyChanged("PortsCollection"); }
    }
