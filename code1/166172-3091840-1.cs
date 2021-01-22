	using System.ComponentModel;
	namespace TestBindingApp
	{
	public class Class1
	{
	    // Singleton instance
	    private static Class1 instance;
	    private string _accountNumber;
	    public Class1()
	    {
	    }
	    // Singleton instance read-only property
	    public static Class1 Instance
	    {
		get
		{
		    if (instance == null)
		    {
			instance = new Class1();
		    }
		    return instance;
		}
	    }
	    public string AccountNumber
	    {
		get
		{
		    return _accountNumber;
		}
		set
		{
		    if (value != _accountNumber)
		    {
			_accountNumber = value;
			    NotifyPropertyChanged("AccountNumber");
		    }
		}
	    }
	    
            public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged(string property)
		{
		    if(PropertyChanged != null)
		        PropertyChanged(this, new PropertyChangedEventArgs(property));
		}
	}
