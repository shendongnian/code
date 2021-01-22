    public class Sorter
    {
      public IAsyncResult BeginSort(IList<T> values, AsyncCallback complete)
      {
        MyAsyncResult asyncResult = new MyAsyncResult();
        Thread t = new Thread(() =>
          {
            // Implement your sorting algorithm here.
            // Periodically check asyncResult.Cancel at safe points.
            asyncResult.Complete();
            if (complete != null)
            {
              complete(asyncResult);
            }
          });
        t.Start();
        return asyncResult;
      }
    
      public void EndSort(IAsyncResult asyncResult)
      {
        MyAsyncResult target = asyncResult as MyAsyncResult;
        if (target == null)
        {
          throw new ArgumentException();
        }
        // Add code here to extract any additional information from the IAsyncResult that 
        // you might want to return to the client. Perhaps this method will be empty.
      }
    
      public void CancelSort(IAsyncResult asyncResult)
      {
        MyAsyncResult target = asyncResult as MyAsyncResult;
        if (target == null)
        {
          throw new ArgumentException();
        }
        target.Cancel = true;
      }
    
      private class MyAsyncResult : IAsyncResult
      {
        private volatile bool m_Cancel = false;
    
        public bool Cancel
        {
          get { return m_Cancel; }
          set { m_Cancel = value; }
        }
    
        public void Complete()
        {
          // Add code here to mark this IAsyncResult as complete.
        }
      }
    }
