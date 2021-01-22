    using System.Threading;
    
    // ...
    
    public partial class MyForm : Form
    {
    	private readonly SynchronizationContext uiContext;
    	
    	public MyForm()
    	{
        	InitializeComponent();
        	uiContext = SynchronizationContext.Current; // get ui thread context
    	}
    	
    	private void button1_Click(object sender, EventArgs e)
        {
        	Thread t = new Thread(() =>
                {// set ui thread context to new thread context                            
                 // for operations with ui elements to be performed in proper thread
                 SynchronizationContext
                     .SetSynchronizationContext(uiContext);
    			 label1.Text = "some text";
                });
    		t.Start();
      	}
    }
