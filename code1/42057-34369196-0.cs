    void setEnableLoginButton()
    {
      if (InvokeRequired)
      {
        // btn_login can be any conroller, (label, button textbox ..etc)
        btn_login.Invoke(new MethodInvoker(setEnable));
        // OR 
        //Invoke(new MethodInvoker(setEnable));
      }
      else {
        setEnable();
      }
    }
    void setEnable()
    {
      btn_login.Enabled = isLoginBtnEnabled;
    }
