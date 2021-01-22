    private object _UFTCallBackFunction = null;
     public int callMeBack2()
     {
     string[] retParts = {"Yep this is value 1"};
     _UFTCallBackFunction.GetType().InvokeMember("", 
      System.Reflection.BindingFlags.InvokeMethod, null, 
    _UFTCallBackFunction, retParts);
     return 0;
     }
 
     public void InitUFTCallBack(object UFTCallBackFunction)
     {
     _UFTCallBackFunction = UFTCallBackFunction;
     }
