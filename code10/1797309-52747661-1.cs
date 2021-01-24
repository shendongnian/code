        public sealed class IntStringAtomicDictionary : IIntStringAtomicDictionary
        {
            private readonly ConcurrentDictionary<int, ValueWrapper<string>> _innerDictionary = new ConcurrentDictionary<int, ValueWrapper<string>>();
            private readonly Func<int, ValueWrapper<string>> _wrapperConstructor = _ => new ValueWrapper<string>();
            public bool AddIfMissingOnly(int key, Func<string> valueGetter)
            {
                var wrapper = _innerDictionary.GetOrAdd(key, _wrapperConstructor);
                return wrapper.AddIfNotExist(valueGetter);
            }
            public bool UpdateIfExists(int key, GetNewValue<string> convertPreviousValueToNew)
            {
                var wrapper = _innerDictionary.GetOrAdd(key, _wrapperConstructor);
                return wrapper.AddIfExists(convertPreviousValueToNew);
            }
        }
        private sealed class ValueWrapper<TValue> where TValue : class
        {
            private readonly object _lock = new object();
            private TValue _value;
            public bool AddIfNotExist(Func<TValue> valueGetter)
            {
                lock (_lock)
                {
                    if (_value is null)
                    {
                        _value = valueGetter();
                        return true;
                    }
                    return false;
                }
            }
            public bool AddIfExists(GetNewValue<TValue> updateValueFunction)
            {
                lock (_lock)
                {
                    if (!(_value is null))
                    {
                        _value = updateValueFunction(_value);
                        return true;
                    }
                    return false;
                }
            }
        }
