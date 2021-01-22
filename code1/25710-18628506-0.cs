    public static class CollectionSlicer
    {
        public static IEnumerable<IEnumerable<T>> Slice<T>(this IEnumerable<T> source, params int[] steps)
        {
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
                        _currentStep = _steps[i];
                    }
                    yield return SliceInternal();
                }
            }
            private IEnumerable<T> SliceInternal()
            {
                for (var count = 0; count < _currentStep; ++count)
                {
                    if (_iterator.MoveNext())
                    {
                        yield return _iterator.Current;
                    }
                    else
                    {
                        _isHasNext = false;
                        break;
                    }
                }
            }
            private readonly IEnumerator<T> _iterator;
            private readonly int[] _steps;
            private volatile bool _isHasNext;
            private volatile int _currentStep;
        }
    }
