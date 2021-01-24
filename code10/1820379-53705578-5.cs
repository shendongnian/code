    [Benchmark]
    public int ValueTypeSum()
    {
        var sum = 0;
        // NOTE: Caching the array to a local variable (that will avoid the reload of the Length inside the loop)
        var arr = _valueTypeData;
        // NOTE: checking against `array.Length` instead of `Size`, to completely remove the ArrayOutOfBound checks
        for (var i = 0; i < arr.Length; i++)
        {
            sum += arr[i].Value;
        }
        return sum;
    }
