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
    }
    public sealed class Slicer<T>
    {
        public Slicer(IEnumerator<T> iterator, int[] steps)
        {
            _iterator = iterator;
            _steps = steps;
            _index = 0;
            _currentStep = 0;
            _isHasNext = true;
        }
        public int Index
        {
            get { return _index; }
        }
        public IEnumerable<IEnumerable<T>> Slice()
        {
            var length = _steps.Length;
            var index = 1;
            var step = 0;
            for (var i = 0; _isHasNext; ++i)
            {
                if (i < length)
                {
                    step = _steps[i];
                    _currentStep = step - 1;
                }
                while (_index < index && _isHasNext)
                {
                    _isHasNext = MoveNext();
                }
                if (_isHasNext)
                {
                    yield return SliceInternal();
                    index += step;
                }
            }
        }
        private IEnumerable<T> SliceInternal()
        {
            if (_currentStep == -1) yield break;
            yield return _iterator.Current;
            for (var count = 0; count < _currentStep && _isHasNext; ++count)
            {
                _isHasNext = MoveNext();
                if (_isHasNext)
                {
                    yield return _iterator.Current;
                }
            }
        }
        private bool MoveNext()
        {
            ++_index;
            return _iterator.MoveNext();
        }
        private readonly IEnumerator<T> _iterator;
        private readonly int[] _steps;
        private volatile bool _isHasNext;
        private volatile int _currentStep;
        private volatile int _index;
    }
