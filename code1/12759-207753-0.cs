    public void Whatever(IRenderable renderable)
    {
       if (renderable is ILocateable)
       {
          ((ILocateable) renderable).LocationChanged += myEventHandler;
       }
       // Do normal stuff
    }
