    [Inject]
    TestInterface Test { get; set; }
    
    private void Form_Load(object sender, EventArgs e)
    {            
        IKernel kernel = ... // Get an instance of IKernel
        kernel.Inject(this);
    
        // Your form dependencies have now been injected and the 
        // Test property is ready to use
    }
