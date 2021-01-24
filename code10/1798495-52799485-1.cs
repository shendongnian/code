    public partial class PackingApproval : Form
    {
    	public PackingApproval(string enterValue)
    	{
    		InitializeComponent();
    		txtBox4.Text = enterValue;
    	}
    }
    public partial class Form1 : Form
    {
    	public Form1()
    	{
    		InitializeComponent();
    	}
    
    	private void btnApprove_Click(object sender, EventArgs e)
    	{
    		var text = txtEvent.Text;
    		PackingApproval pa = new PackingApproval(text);
    		pa.Show();
    	}
    }
