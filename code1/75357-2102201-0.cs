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
                for (int i = 0; i < this.CommandCollection.Length; i++)
                    if (this.CommandCollection[i] != null)
                     this.CommandCollection[i].CommandTimeout = value;
        }
      }
    }
