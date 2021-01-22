    partial void DeleteUnit(Unit instance)    
    {        
       //instance.DLDAT = DateTime.Now;        
       //this.ExecuteDynamicUpdate(instance);
       PdpDataContext cx = new PdpDataContext();
       cx.ObjectTrackingEnabled = true;
       Unit u = new Unit();
       u = cx.Unit.Single(x => x.INTUNITNO == 1);
       u.DLDAT = DateTime.Now;
       cx.SubmitChanges();
    }
