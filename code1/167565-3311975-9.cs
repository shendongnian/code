    public class Form1
    {
    
    
    	TextBoxFilter filter = new TextBoxFilter();
    	private void Form1_Load(object sender, System.EventArgs e)
    	{
    		filter.SetTextBoxFilter(TextBox1, TextBoxFilter.Filters.Numbers);
    	}
    	public Form1()
    	{
    		Load += Form1_Load;
    	}
    }
