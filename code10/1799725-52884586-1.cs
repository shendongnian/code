    public interface ICommand
    {
        object Execute();
        Boolean TryExecute(out object result);
        Task<object> BeginExecute();        
    }
    namespace Generic
    {
        public interface ICommand<TResult> : ICommand
        {
            new TResult Execute();
            Boolean TryExecute(out TResult result);
            new Task<TResult> BeginExecute();
        }
    }
    public class Command : ICommand
    {
        private Func<ICommand, object> _execFunc = null;
        protected Func<ICommand, object> ExecFunc { get { return _execFunc; } }
        public Task<object> BeginExecute()
        {
            return Task<object>.Factory.StartNew(() => _execFunc(this) );
        }
        public object Execute()
        {
            return _execFunc(this);
        }
        public bool TryExecute(out object result)
        {
            try
            {
                result = _execFunc(this);
                return true;
            }
            catch(Exception ex)
            {
                result = null;
                return false;
            }
        }
        public Command (Func<ICommand, object> execFunc)
        {
            if (execFunc == null) throw new ArgumentNullException("execFunc");
            _execFunc = execFunc;
        }
    }
    namespace Generic
    {
        public class Command<TResult> : Command, ICommand<TResult> where TResult : class            
        {
            new protected Func<ICommand<TResult>, TResult> ExecFunc => (ICommand<TResult> cmd) => (TResult)base.ExecFunc(cmd);
            public bool TryExecute(out TResult result)
            {
                try
                {
                    result = ExecFunc(this);
                    return true;
                }
                catch(Exception ex)
                {
                    result = null;
                    return false;
                }
            }
            Task<TResult> ICommand<TResult>.BeginExecute()
            {
                return Task<TResult>.Factory.StartNew(() => ExecFunc(this) );
            }
            TResult ICommand<TResult>.Execute()
            {
                return ExecFunc(this);
            }
            public Command(Func<ICommand<TResult>, TResult> execFunc) : base((ICommand c) => (object)execFunc((ICommand<TResult>)c))
            {
            }
        }
    }
    public class ConcatCommand : Generic.Command<string> 
    {
        private IEnumerable<string> _inputs;
        public IEnumerable<String> Inputs => _inputs;
        
        public ConcatCommand(IEnumerable<String> inputs) : base( (Generic.ICommand<string> c) => (string)String.Concat(((ConcatCommand)c).Inputs) )
        {
            if (inputs == null) throw new ArgumentNullException("inputs");
            _inputs = inputs;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = { "This", " is ", " a ", " very ", " fine ", " wine!" };
            ICommand c = new ConcatCommand(inputs );
            string results = (string)c.Execute();
            Console.WriteLine(results);
            Console.ReadLine();
        }
    }
