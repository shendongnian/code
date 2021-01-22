    public static class CollectionSlicer
    {
        public static IEnumerable<IEnumerable<T>> Slice<T>(this IEnumerable<T> source, params int[] steps)
        {
            if (!steps.Any(step => step != 0))
            {
                throw new InvalidOperationException("Can't slice a collection with step length 0.");
            }
            return new Slicer<T>(source.GetEnumerator(), steps).Slice();
        }
        private sealed class Slicer<T>
        {
            internal Slicer(IEnumerator<T> iterator, int[] steps)
            {
                _iterator = iterator;
                _steps = steps;
                _isHasNext = true;
            }
            internal IEnumerable<IEnumerable<T>> Slice()
            {
                var length = _steps.Length;
                for (var i = 0; _isHasNext; ++i)
                {
                    if (i < length)
                    {
                        _currentStep = _steps[i] - 1;
                    }
                    _isHasNext = _iterator.MoveNext();
                    if (_isHasNext)
                    {
                        yield return SliceInternal();
                    }
                }
            }
            private IEnumerable<T> SliceInternal()
            {
                if (_currentStep == -1) yield break;
                yield return _iterator.Current;
                for (var count = 0; count < _currentStep && _isHasNext; ++count)
                {
                    _isHasNext = _iterator.MoveNext();
                    if (_isHasNext)
                    {
                        yield return _iterator.Current;
                    }
                }
            }
            private readonly IEnumerator<T> _iterator;
            private readonly int[] _steps;
            private volatile bool _isHasNext;
            private volatile int _currentStep;
        }
    }
