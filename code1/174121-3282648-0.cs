    public class AsynchronousBlockingCollection<T> : BlockingCollection<T>
    {
        public IAsyncResult BeginTake(AsyncCallback callback, object state)
        {
            Func<T> action = () => Take();
            return action.BeginInvoke(callback, Tuple.Create(state, action));
        }
    
        public T EndTake(IAsyncResult asyncResult)
        {
            var tuple = (Tuple<object, Func<T>>)asyncResult.AsyncState;
            return tuple.Item2.EndInvoke(asyncResult);
        }
    }
