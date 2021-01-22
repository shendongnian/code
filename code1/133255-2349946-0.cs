      void M()
      {
        try
        {
          if (blah)
          {
            Frob();
            Blob();
          }
        }
        catch(Exception ex)
        { /* eat it */ }
        finally
        {
          Grob();
        }
      }
