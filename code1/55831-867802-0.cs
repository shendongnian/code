    public partial class Form1 : Form
    {
    	class Customer
    	{
    		public string FirstName { get; set; }
    		public string LastName { get; set; }
    
    		public override string ToString()
    		{
    			return string.Format("{0} {1}", LastName, FirstName);
    		}
    	}
    
    	public Form1() { InitializeComponent(); }
    
    	protected override void OnLoad(EventArgs e)
    	{
    		base.OnLoad(e);                        
    		listBox1.DisplayMember = "LastName";            
    		listBox1.DataSource = GetCustomers();
    		//listBox1.Items.AddRange(GetCustomers().ToArray());            
    	}
    
    	private IEnumerable<Customer> GetCustomers()
    	{
    		return new List<Customer>()
    		{
    			new Customer() { FirstName = "Gustav", LastName = "MAHLER" },
    			new Customer() { FirstName = "Johann Sebastian", LastName = "BACH" }
    		};
    	}
    
    	private void lb_SelectedIndexChanged(object sender, EventArgs e)
    	{
    		label1.Text = listBox1.SelectedItem.ToString();
    	}        
    }
