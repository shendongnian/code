    interface IMappable: IRenderable, ILocateable {}
    public void Whatever(IMappable mappable)
    {
       mappable.LocationChanged += myEventHandler;
       // Do normal stuff
    }    
