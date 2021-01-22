    IDesignerHost _host;
    Form _form;
    public override void Initialize(System.ComponentModel.IComponent component)
    {
      _form = component as Form;
      _host = (IDesignerHost)this.GetService(typeof(IDesignerHost));
      if (_host != null)
      {      
       if (_host.Loading)
       {
         _host.LoadComplete += new EventHandler(_host_LoadComplete);
       }
       else
       {
         initializeForm();
       }
      }
    }
    void _host_LoadComplete(object sender, EventArgs e)
    {
      _host.LoadComplete -= new EventHandler(_host_LoadComplete);
      initializeForm();
    }
    void initializeForm()
    {
       if (_form!= null)
       {
          ...
       }
    }
