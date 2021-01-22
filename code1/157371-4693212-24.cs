      internal class StackPopper : IDisposable
      {
        int pc;
        IContextStack st;
    
        public StackPopper(int prevCount, IContextStack stack)
        {
          pc = prevCount;
          st = stack;
        }
    
        #region IDisposable Members
    
        public void Dispose()
        {
          while (st.Count > pc)
          {
            st.Pop();
          }
        }
    
        #endregion
      }
