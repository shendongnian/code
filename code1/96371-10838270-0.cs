    static void Main(string[] args)
    {
        // one shot
        var res = Retry<string>.Do(() => retryThis("try"), 4, TimeSpan.FromSeconds(2), fix);
    
        // delayed execute
        var retry = new Retry<string>(() => retryThis("try"), 4, TimeSpan.FromSeconds(2), fix);
        var res2 = retry.Execute();
    }
    
    static void fix()
    {
        Console.WriteLine("oh, no! Fix and retry!!!");
    }
    
    static string retryThis(string tryThis)
    {
        Console.WriteLine("Let's try!!!");
        throw new Exception(tryThis);
    }
    public class Retry<T>
    {
        Expression<Func<T>> _Method;
        int _NumRetries;
        TimeSpan _RetryTimeout;
        Action _OnFailureAction;
    
        public Retry(Expression<Func<T>> method, int numRetries, TimeSpan retryTimeout, Action onFailureAction)
        {
            _Method = method;
            _NumRetries = numRetries;
            _OnFailureAction = onFailureAction;
            _RetryTimeout = retryTimeout;
        }
    
        public T Execute()
        {
            T result = default(T);
            while (_NumRetries > 0)
            {
                try
                {
                    result = _Method.Compile()();
                    break;
                }
                catch
                {
                    _OnFailureAction();
                    _NumRetries--;
                    if (_NumRetries <= 0) throw; // improved to avoid silent failure
                    Thread.Sleep(_RetryTimeout);
                }
            }
            return result;
        }
    
        public static T Do(Expression<Func<T>> method, int numRetries, TimeSpan retryTimeout, Action onFailureAction)
        {
            var retry = new Retry<T>(method, numRetries, retryTimeout, onFailureAction);
            return retry.Execute();
        }
    }
