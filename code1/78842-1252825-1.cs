    public void GuiMethod(object param)
    {
       if(this.InvokeRequired)
       {
          this.Invoke(delgateToGuiMethod, params,...)
       }
       else
       {
          //perform gui thread method
       }
    }
