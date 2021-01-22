    public static void InvokeIfNecessary(Form form, MethodInvoker action)
    {    
         if (form.InvokeRequired)    
         {        
              form.Invoke(DispatcherPriority.Normal, action);    
         }    
         else    
         {        
              action();    
         }
    }
  
    public static void EnableLogin(int enabled)    
    {        
        var form = Form.ActiveForm as FormMain;        
        if (form != null)            
            InvokeIfNecessary(form, delegate { form.btnLogin.Enabled = (enabled != 0) });    
    }
