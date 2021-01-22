    public partial class Form1 : Form
    {
    	public Form1()
    	{
    		InitializeComponent();
    
    		tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
    	}
    
    	void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    	{
    		ProcessStartInfo psi = null;
    
    		if (tabControl1.SelectedTab == tabPage1)
    		{
    			psi = new ProcessStartInfo("notepad.exe");
    		}
    		else if (tabControl1.SelectedTab == tabPage2)
    		{
    			psi = new ProcessStartInfo("calc.exe");
    		}
    
    		if (psi != null)
    		{
    			psi.ErrorDialog = true;
    			psi.ErrorDialogParentHandle = Handle;
    			Process.Start(psi);
    		}
    	}
    }
