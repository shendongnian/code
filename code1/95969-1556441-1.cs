    public class DoAsAsync
    {
        private Action action;
        private bool ended;
        public DoAsAsync(Action action)
        {
            this.action = action;
        }
        public void Execute()
        {
            action.BeginInvoke(new AsyncCallback(End), null);
        }
        private void End(IAsyncResult result)
        {
            if (ended)
                return;
            try
            {
                ((Action)((AsyncResult)result).AsyncDelegate).EndInvoke(result);
            }
            catch
            {
                /* do something */
            }
            finally
            {
                ended = true;
            }
        }
    }
