    interface IRenderable: ILocateable
    {
      // IRenderable interface
    }
    public void Whatever(IRenderable renderable)
    {
       renderable.LocationChanged += myEventHandler;
       // Do normal stuff
    }  
