    public void TryThis(Action doFirst, Action doSecond)
    {
      try { 
          doFirst();
      }
      catch (DocumentClientException dce1) {
          try {
              doSecond();
          }
          catch (DocumentClientException dce2) {
              log to app insights.
          }
      }
    }
