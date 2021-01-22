    public class EventArgs<T> : EventArgs
    {
    	public EventArgs(T value)
    	{
    		m_value = value;
    	}
    
    	private T m_value;
    
    	public T Value
    	{
    		get { return m_value; }
    	}
    }
    
    public event EventArgs<BatchItemResponse> ItemProcessed;
    
    public void Process(List<BatchItem> Data)
    {
    	foreach (BatchItem item in Data)
    	{
    		BatchItemResponse result = new BatchItemResponse();
    		result.Processed = ProcessItem(item);
    		if (ItemProcessed != null)
    		{
    			ItemProcessed(this, new EventArgs<BatchItemResponse>(result));
    		}
    	}
    }
