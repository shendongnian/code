        public class DogViewModel : INotifyPropertyChanged
        {
    	    public event PropertyChangedEventHandler PropertyChanged;
    	    private ObservableCollection<Dog> _dogs;
    	    public ObservableCollection<Dog> Dogs
    	    {
    		    get { return _dogs; }
    		    set
    		    {
    			    _dogs = value;
    			    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Dogs"));
    		    }
    	    }
    	    public void LoadData()
    	    {
    		    // ....
    	    }
        }
