    public class ReportContainer{
              public ReportContainer ( IReportEngine reportEngine, IStorageEngine storage, IDeliveryEngine delivery...)
    }
    }
    
    /// In your service layer you resolve which engines to use
    // Either with a bunch of if statements / Factory / config ... 
    
    IReportEngine rptEngine = EngineFactory.GetEngine<IReportEngine>( pass in some values)
    
    IStorageEngine stgEngine = EngineFactory.GetEngine<IStorageEngien>(pass in some values)
    
    IDeliverEngine delEngine = EngineFactory.GetEngine<IDeliverEngine>(pass in some values)
    
    
    
    ReportContainer currentContext = new ReportContainer (rptEngine, stgEngine,delEngine);
