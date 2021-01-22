        public IEnumerator<T> GetEnumerator()
        {
            int index = 0;
            while (true)
            {
                if (index < _cache.Count)
                {
                    yield return _cache[index];
                    index = index + 1;
                }
                else
                {
                    if (_enumerator.MoveNext())
                    {
                        _cache.Add(_enumerator.Current);
                    }
                    else
                    {
                        yield break;
                    }
                }
            }
        }
