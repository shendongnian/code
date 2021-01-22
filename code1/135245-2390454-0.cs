    protected void btnTest_Click(object sender, EventArgs e)
    {
       SomeSub();
    }
    
    protected void SomeOtherFunctionThatNeedsToCallTheCode()
    {
       SomeSub();
    }
    
    protected void SomeSub()
    {
       // ...
    }
