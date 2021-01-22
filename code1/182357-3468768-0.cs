    public delegate void UpdateLabelStatus(string status);
    
    ...
    
    private void test()
    {
    
         Invoke(new UpdateLabelStatus(LabelStatus1), status);
         ...
    
    }
    
    private void LabelStatus1(string status)
    {
    
         Label1.Text = status;
    }
