    int intOriginalExStyle = -1;
    bool bEnableAntiFlicker = true;
    
    public Form1()
    {
    	ToggleAntiFlicker(false);
    	InitializeComponent();
    	this.ResizeBegin += new EventHandler(Form1_ResizeBegin);
    	this.ResizeEnd += new EventHandler(Form1_ResizeEnd);
    }
    
    protected override CreateParams CreateParams
    {
    	get
    	{
    		if (intOriginalExStyle == -1)
    		{
    			intOriginalExStyle = base.CreateParams.ExStyle;
    		}
    		CreateParams cp = base.CreateParams;
    
    		if (bEnableAntiFlicker)
    		{
    			cp.ExStyle |= 0x02000000; //WS_EX_COMPOSITED
    		}
    		else
    		{
    			cp.ExStyle = intOriginalExStyle;
    		}
    
    		return cp;
    	}
    } 
    
    private void Form1_ResizeBegin(object sender, EventArgs e)
    {
    	ToggleAntiFlicker(true);
    }
    
    private void Form1_ResizeEnd(object sender, EventArgs e)
    {
    	ToggleAntiFlicker(false);
    }
    
    private void ToggleAntiFlicker(bool Enable)
    {
    	bEnableAntiFlicker = Enable;
    	//hacky, but works
    	this.MaximizeBox = true;
    }
