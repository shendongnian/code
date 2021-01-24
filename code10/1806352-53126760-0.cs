     public void SafeExecute(IView form, Action methodToExecute)
     {
          // args chek....
          ISynchronizeInvoke view = form as ISynchronizeInvoke;
          if(view != null)
          {
            if (!View.InvokeRequired)
                {
                    methodToExecute();
                }
                else
                {
                    view.Invoke(methodToExecute, null);
                }
          }
          else methodToExecute();
     }
