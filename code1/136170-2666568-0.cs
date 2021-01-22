    MyDomainContext proxy;
    public void Initialize()
    {
        //create proxy to Domain Service  
        proxy = new RIAService.Web.DomainContext();
    
        //load Presentation - LOAD STEP 1
        Load(proxy.GetPresentationsQuery(), LoadPresentations_Completed, null);
    }
    
    void LoadPresentations_Completed(LoadOperation<PresentationEntity> loadOp)
    {
      if (loadOp.HasError)
      {
         //process error here
         loadOp.MarkErrorAsHandled = true;
      }
      else
      {
          - LOAD STEP 2
         var loadTopics = proxy.Load(proxy.GetTopicsQuery());
         loadTopics.Completed += new EventHandler(loadTopics_Completed);
      }
    }
    void loadTopics_Completed(object sender, EventArgs e)
    {
      //bind presentation entities to XAML      
    }
