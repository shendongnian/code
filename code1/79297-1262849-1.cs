    class Customer
    {
      private string _lazydata = null;
    
      public string LazyData
      {
        get
        {
          if (this._lazydata==null)
          {
            LazyPopulate();
          }
          return this._lazydata;
        }
      }
    
      private void LazyPopulate()
      {
        /* fetch data and set lazy fields */
      }
    }
