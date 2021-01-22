    button1_click()
    {
      RemoteClass obj = Activator.GetObject(typeof(RemoteClass), "object URI");
      if(RemotingServices.IsTransparentProxy(obj))
      {
          MessageBox.Show(obj.Myval.ToString());
      }
    }
