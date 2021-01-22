    public class Form1 : Form
    {
    	public DataAccess Db { get; set; }
    
    	public void UpdateSomething()
    	{
    		this.textbox.Text = this.Db.GetSomeDatabaseValue();
    	}
    }
