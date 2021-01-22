    private void MethodA() { }
    
    protected void Button_Click(object sender, EventArgs e)
    {
        string arg = ((Button)sender).CommandArgument;  // = MethodA
        MethodInfo method = this.GetType().GetMethod(arg);
        method.Invoke(this, null);
    }
