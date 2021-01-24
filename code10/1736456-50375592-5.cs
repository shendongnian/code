    	    public class Dog : INotifyPropertyChanged
            {
                public event PropertyChangedEventHandler PropertyChanged;
                private string _name;
                private int _number;     
                public string Name
    	        {
    		        get => _name;
    		        set
    		        {
    			         if (_name != value)
    			         { 
    				        _name = value;
    				        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
    			         }
    		        }
    	        }
    
    	        public int Number
    	        {
    		        get => _number;
    		        set
    		        {
    			        if (_number != value)
    			        {
    				        _number = value;
    				        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Number"));
    			        }
    		        }
    	        }
            }
