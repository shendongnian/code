    class ViewModelBase : INotifyPropertyChanged {
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	bool Notify<T>(MethodBase mb, ref T oldValue, T newValue) {
    
    		// Get Name of Property
    		string name = mb.Name.Substring(4);
    
    		// Detect Change
    		bool changed = EqualityComparer<T>.Default.Equals(oldValue, newValue);
    
    		// Return if no change
    		if (!changed) return false;
    
    		// Update value
    		oldValue = newValue;
    
    		// Raise Event
    		if (PropertyChanged != null) {
    			PropertyChanged(this, new PropertyChangedEventArgs(name));
    		}//if
    
    		// Notify caller of change
    		return true;
    
    	}//method
    
    	string name;
    
    	public string Name {
    		get { return name; }
    		set {
    			Notify(MethodInfo.GetCurrentMethod(), ref this.name, value);
    		}
    	}//method
    
    }//class
