    namespace xxx.xxxTableAdapters
    partial class FooTableAdapter
    {
      /**
       * <summary>
       * Set timeout in seconds for Select statements.
       * </summary>
       */
      public int SelectCommandTimeout
      {
        set
        {
            if (this.CommandCollection == null)
                    this.InitCommandCollection();
   
            for (int i = 0; i < this.CommandCollection.Length; i++)
                if (this.CommandCollection[i] != null)
                 this.CommandCollection[i].CommandTimeout = value;
        }
      }
    }
