    public class BaseContextMenu<T> : IContextMenu
    {
        private T executor;
        public void Exec(Action<T> action)
        {
            action.Invoke(this.executor);
        }
        public void ExecAsync(Action<T> asyncAction, AsyncCallback callback)
        {
            asyncAction.BeginInvoke(this.executor, callback, asyncAction);
        }
    }
