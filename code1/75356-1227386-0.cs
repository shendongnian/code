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
          for ( int n=0; n < _commandCollection.Length; ++n )
            if ( _commandCollection[n] != null )
              ((System.Data.SqlClient.SqlCommand)_commandCollection[n])
                .commandTimeout = value;
        }
      }
    }
