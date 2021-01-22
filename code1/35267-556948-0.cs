    public class ValueReader
    {
    	List<IDataReader> _list = new List<IDataReader>();
      
    	object _criticalSection = new object();
      
    	  public ValueReader()
    	  {
    	    //Nothign here
    	  }
      
    	  public void Attach(IDataReader reader)
    	  {
    			lock(_criticalSection)
    			{
    				_list.Add(reader);
    			}
    	  }
      
    	  public void Detach(IDataReader reader)
    	  {
    			lock(_criticalSection)
    			{
    				_list.Remove(reader);
    			}
    	  }
      
    	  public void Notify(string value)
    	  {
    			lock(_criticalSection)
    			{
    				foreach(IDataReader reader in _list)
    				{
    					reader.Update(value);
    				}
    			}
    		}
      
    	  public void Start()
    	  {
    			new Thread(new ThreadStart(Run)).Start();
    	  }
      
      
    	  private void Run()
    	  {
    			while(true)
    			{
    			
    				//generate value
    				Notify(value);
    			  
    				Thread.Sleep(5000);
    			
    			}
    	  } 
      
    }
    
    
    
    
    public interface IDataReader
    {
    	void UpdateControls(string value);
    }
    
    public class FirstClass : IDataReader
    {
    	
    	....
    	......	
    	ValueReader _reader = null;
    	
    	public FirstClass()
    	{
    	
    		_reader = new ValueReader();
                  _reader.Start();
    		_reader.Attach(this);
    		
    	}
    	
    	private void AddToSmartClient()
    	{
    		// _reader has added to SmartClient's WorkItem
    	}
    	
    	
    	private delegate void UpdateControlDelegate(string value);
    	
    	public void UpdateControl(string value)
    	{
    		if(txtAddress.InvokeRequired)
    		{
    			txtAddress.Invoke(new UpdateControlDelegate(UpdateControl), value);
    		}
    		else
    		{
    			txtAddress.Text = value;
    			txtValue.Text = value;
    		}
    	}
    
    }
    
    
    public class SecondClass : IDataReader
    {
    		....
    	......
    	ValueReader _reader = null;
    	
    	public void SecondClass()
    	{
    		_reader = ReadFromSmartClient();
    		_reader.Attach(this);
    	}
    	
    	private ValueReader ReadFromSmartClient()
    	{
    		reader = //Get from SmartClient's Workitem.
    		return reader
    	}
    	
    	private delegate void UpdateControlDelegate(string value);
    	
    	public void UpdateControl(string value)
    	{
    		if(InvokeRequired)
    		{
    			BeginInvoke(new UpdateControlDelegate(UpdateControl), value);
    		}
    		else
    		{
    			control1.Text = value;
    			control2.Text = value;
    		}
    	}
    
    }
