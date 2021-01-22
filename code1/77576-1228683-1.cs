    protected void MyMethod(){
        RunMethod(ParamMethod("World"));
    }
    
    protected void RunMethod(Func<string> method){
        MessageBox.Show(method());
    }
    
    protected String ParamMethod(String sWho){
        return "Hello " + sWho;
    }
