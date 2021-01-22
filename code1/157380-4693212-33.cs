      class ThreadStack : IContextStack, IEnumerable<object>
      {
        const string slot = "EGFContext.ThreadContextStack";
    
        private static Stack<object> GetThreadStack
        {
          get
          {
            Stack<object> stack = CallContext.LogicalGetData(slot) as Stack<object>;
            if (stack == null)
            {
              stack = new Stack<object>();
              CallContext.LogicalSetData(slot, stack);
            }
            return stack;
          }
        }
    
        #region IContextStack Members
    
        public IDisposable Push(object item)
        {
          Stack<object> s = GetThreadStack;
          int prevCount = s.Count;
          GetThreadStack.Push(item);
      
          return new StackPopper(prevCount, this);
        }
    
        public object Pop()
        {
          object top = GetThreadStack.Pop();
    
          if (GetThreadStack.Count == 0)
          {
            CallContext.FreeNamedDataSlot(slot);
          }
    
          return top;
        }
    
        public object Peek()
        {
          return Count > 0 ? GetThreadStack.Peek() : null;
        }
    
        public void Clear()
        {
          GetThreadStack.Clear();
    
          CallContext.FreeNamedDataSlot(slot);
        }
    
        public int Count { get { return GetThreadStack.Count; } }
    
        public IEnumerable<object> Items 
        { 
          get
          {
            return GetThreadStack;
          }
        }
    
        #endregion
    
        #region IEnumerable<object> Members
    
        public IEnumerator<object> GetEnumerator()
        {
          return GetThreadStack.GetEnumerator();
        }
    
        #endregion
    
        #region IEnumerable Members
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
          return GetThreadStack.GetEnumerator();
        }
    
        #endregion
      }
