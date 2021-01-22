    public partial class MyForm : Form
    {        
    	public MyForm()
    	{
    		if (weShouldClose)
    		{
    			Environment.Exit(0);
    		}
    	}
    }
