    public class MyClass
    {
    	private IMyInterface m_field;
    	public Control FieldAsControl
    	{
    		get { return m_field as Control; }
    	}
    	public IMyInterface Field
    	{
    		get { return m_field; }
    		set
    		{
    			if (m_field is Control)
    			{
    				m_field = value;
    			}
    			else
    			{
    				throw new ArgumentException();
    			}
    		}
    	}
    }
