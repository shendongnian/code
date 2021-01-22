    public class ListBoxWriter : TextWriter
    {
    	private ListBox list;
    	private StringBuilder content = new StringBuilder();
    
    	public ListBoxWriter(ListBox list)
    	{
    		this.list = list;
    	}
    
    	public override void Write(char value)
    	{
    		base.Write(value);
    		content.Append(value);
    		if (value == '\n')
    		{
    			list.Items.Add(content.ToString());
    			content = new StringBuilder();
    		}
    	}
    
    	public override Encoding Encoding
    	{
    		get { return System.Text.Encoding.UTF8; }
    	}
    }
