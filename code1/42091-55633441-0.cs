    using System.Threading;
    
    // ...
    
    public partial class MyForm : Form
    {
    	private readonly SynchronizationContext uiContext;
    	
    	public MyForm()
    	{
        	InitializeComponent();
        	uiContext = SynchronizationContext.Current;
    	}
    	
    	private void button1_Click(object sender, EventArgs e)
        {
        	Thread t = new Thread(() => { SynchronizationContext.SetSynchronizationContext(uiContext);
    								      label1.Text = "some text"; });
    		t.Start();
      	}
    }
