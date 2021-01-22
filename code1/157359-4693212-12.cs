      class CorrelationManagerStack : IContextStack, IEnumerable<object>
      {
        #region IContextStack Members
    
        public IDisposable Push(object item)
        {
          Trace.CorrelationManager.StartLogicalOperation(item);
    
          return new StackPopper(Count - 1, this);
        }
    
        public object Pop()
        {
          object operation = null;
          
          if (Count > 0)
          {
            operation = Peek();
            Trace.CorrelationManager.StopLogicalOperation();
          }
    
          return operation;
        }
    
        public object Peek()
        {
          object operation = null;
    
          if (Count > 0)
          {
            operation = Trace.CorrelationManager.LogicalOperationStack.Peek();
          }
    
          return operation;
        }
    
        public void Clear()
        {
          Trace.CorrelationManager.LogicalOperationStack.Clear();
        }
    
        public int Count
        {
          get { return Trace.CorrelationManager.LogicalOperationStack.Count; }
        }
    
        public IEnumerable<object> Items
        {
          get { return Trace.CorrelationManager.LogicalOperationStack.ToArray(); }
        }
    
        #endregion
    
        #region IEnumerable<object> Members
    
        public IEnumerator<object> GetEnumerator()
        {
          return (IEnumerator<object>)(Trace.CorrelationManager.LogicalOperationStack.ToArray().GetEnumerator());
        }
    
        #endregion
    
        #region IEnumerable Members
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
          return Trace.CorrelationManager.LogicalOperationStack.ToArray().GetEnumerator();
        }
    
        #endregion
    
      }
