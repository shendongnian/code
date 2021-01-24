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
    	private string _setPackagingApprovalText;
    	public string SetPackagingApprovalText
    	{
    		get
    		{
    			return _setPackagingApprovalText;
    		}
    		set
    		{
    			txtBox4.Text = value;
    			_setPackagingApprovalText = value;
    		}
    	}
    	public PackingApproval()
    	{
    		InitializeComponent();
    	}
    }
