    public class Worker
    {
      private IHelper _helper;
      public Worker()
        : this (new DefaultHelper())
      {
      }
      public Worker(IHelper helper)
      {
        this._helper = helper;
      }
    
      private class DefaultHelper : IHelper
      {
      }
    }
