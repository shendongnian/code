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
    		SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=Juan Carlo SCM;Persist Security Info=True;User ID=sa;Password=benilde");
    		con.Open();
    		SqlCommand sc = new SqlCommand("SELECT EventName FROM Event_Table WHERE EventID=@EventID", con);
    
    		sc.Parameters.Add(new SqlParameter("EventID", int.Parse(SetPackagingApprovalText)));
    		SqlDataReader reader;
    		reader = sc.ExecuteReader();
    		if (reader.HasRows)
    		{
    			reader.Read();
    			txtBox4.Text = reader["EventName"].ToString();
    		}
    
    		reader.Close();
    		con.Close();
    	}
    }
