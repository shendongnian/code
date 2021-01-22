    /// <summary>
    /// Slice an array as Python.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="start">start index.</param>
    /// <param name="end">end index.</param>
    /// <param name="step">step</param>
    /// <returns></returns>
    /// <remarks>
    /// http://docs.python.org/2/tutorial/introduction.html#strings
    ///      +---+---+---+---+---+
    ///      | H | e | l | p | A |
    ///      +---+---+---+---+---+
    ///      0   1   2   3   4   5
    /// -6  -5  -4  -3  -2  -1    
    /// </remarks>
    public static IEnumerable<T> Slice<T>(this T[] array,
        int? start = null, int? end = null, int step = 1)
    {
        array.NullArgumentCheck("array");
        // step
        if (step == 0)
        {
            // handle gracefully
            yield break;
        }
        // step > 0
        int _start = 0;
        int _end = array.Length;
        // step < 0
        if (step < 0)
        {
            _start = -1;
            _end = -array.Length - 1;
        }
        // inputs
        _start = start ?? _start;
        _end = end ?? _end;
        // get positive index for given index
        Func<int, int, int> toPositiveIndex = (int index, int length) =>
        {
            return index >= 0 ? index : index + length;
        };
        // start
        if (_start < -array.Length || _start >= array.Length)
        {
            yield break;
        }
        if (_start < 0)
        {
            _start = toPositiveIndex(_start, array.Length);
        }
        // end
        if (_end < -array.Length - 1)
        {
            yield break;
        }
        if (_end > array.Length)
        {
            _end = array.Length;
        }
        if (_end < 0)
        {
            _end = toPositiveIndex(_end, array.Length);
        }
        // slice
        if (step > 0)
        {
            // start, end
            if (_start > _end)
            {
                yield break;
            }
            for (int index = _start; index < _end; index += step)
            {
                yield return array[index];
            }
        }
        else
        {
            // start, end
            if (_end > _start)
            {
                yield break;
            }
            for (int index = _start; index > _end; index += step)
            {
                yield return array[index];
            }
        }
    }
