    public static class CompiledExtensions
        {
            private static Dictionary<string, object> _dictionary = new Dictionary<string, object>();
    
            public static IEnumerable<TResult> Cache<TArg, TResult>(this IEnumerable<TArg> list, string name, Expression<Func<IEnumerable<TArg>, IEnumerable<TResult>>> expression)
            {
                Func<IEnumerable<TArg>,IEnumerable<TResult>> _pointer;
    
                if (_dictionary.ContainsKey(name))
                {
                    _pointer = _dictionary[name] as Func<IEnumerable<TArg>, IEnumerable<TResult>>;
                }
                else
                {
                    _pointer = expression.Compile();
                    _dictionary.Add(name, _pointer as object);
                }
    
                IEnumerable<TResult> result = default(IEnumerable<TResult>);
                result = _pointer(list);
    
                return result;
            }
        }
