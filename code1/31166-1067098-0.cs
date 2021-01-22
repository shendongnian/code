    Form1_Load(object sender, EventArgs e)
    {
       RemotingConfiguration.Configure("path of the config file");
       RemoteClass obj = new RemoteClass();
       obj.MyVal =100;
       
       RemotingServices.Marshal(obj);
    }
    
    
    public RemoteClass: MarshalByRefObj
    {
       static int Counter;
       public RemoteClass()
       {
          Counter++;
       }
    
       int _MyVal =0;
      public int MyVal
     {
        get
       {
          return _MyVal;
       }
       set
       {
          _MyVal = value;
       }
     }       
    }
