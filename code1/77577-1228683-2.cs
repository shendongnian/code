    // Declare a delegate for the method we're passing.
    delegate string MyDelegateType();
    protected void MyMethod(){
        RunMethod(ParamMethod("World"));
    }
    
    protected void RunMethod(MyDelegateType method){
        MessageBox.Show(method());
    }
    
    protected String ParamMethod(String sWho){
        return "Hello " + sWho;
    }
