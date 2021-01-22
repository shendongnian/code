    public BaseForm()
    {
     InitializeComponent();
     this.Size=new Size(20,20);
    }
    bool resizing;
    
    protected override void OnResize(EventArgs e)
    {	
     if(!resizing)
     {
       resizing = true;
       try
       {
         this.Size = new Size(20, 20);
       }
       finally
       {
         resizing = false;
       }
     }
     else
       base.OnResize(e);
    }
