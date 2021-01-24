    public partial class Form1 : Form
    {
    	public Form1()
    	{
    		InitializeComponent();
    	}
    
    	private void btnApprove_Click(object sender, EventArgs e)
    	{
    		var text = txtEvent.Text;
    		PackingApproval pa = new PackingApproval();
    		pa.SetPackagingApprovalText = text;
    		pa.Show();
    	}
    }
    public partial class PackingApproval : Form
    {
    	public string SetPackagingApprovalText;
    	public PackingApproval()
    	{
    		InitializeComponent();
    	}
    
    	private void PackingApproval_Load(object sender, EventArgs e)
    	{
    		txtBox4.Text = SetPackagingApprovalText;
    	}
    }
